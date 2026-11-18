using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Practice_1 {
    public partial class Form1 : Form { Stopwatch stopwatch = new Stopwatch(); CancellationTokenSource? cts; int foundCount = 0; int totalCount = 0;
    public Form1()
    {
        InitializeComponent();
        button2.Click += button2_Click; // "Остановить" не был подключён в дизайнере
    }

    // Пустой обработчик — дизайнер уже подключил это событие к textBox1
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    // Обработчик кнопки "Поиск" (button1)
    private async void button1_Click(object sender, EventArgs e)
    {
        string root = textBox1.Text.Trim(); // стартовая директория
        string patternRaw = textBox2.Text.Trim(); // шаблон имени файла

        if (string.IsNullOrEmpty(root) || !Directory.Exists(root))
        {
            MessageBox.Show("Укажите корректную стартовую директорию.");
            return;
        }

        string ext = "." + patternRaw.TrimStart('*', '.');

        treeView1.Nodes.Clear();
        foundCount = 0;
        totalCount = 0;

        string rootLabel = Path.GetFileName(root.TrimEnd(Path.DirectorySeparatorChar));
        if (string.IsNullOrEmpty(rootLabel)) rootLabel = root;
        var rootNode = new TreeNode(rootLabel) { Tag = root };
        treeView1.Nodes.Add(rootNode);
        rootNode.Expand();

        cts = new CancellationTokenSource();
        button1.Enabled = false;
        button2.Enabled = true;
        stopwatch.Restart();
        timer1.Start();

        try
        {
            await Task.Run(() => SearchDirectory(root, ext, rootNode, cts.Token));
        }
        catch (OperationCanceledException)
        {
            // поиск остановлен пользователем
        }
        finally
        {
            stopwatch.Stop();
            timer1.Stop();
            label3.Text = stopwatch.Elapsed.ToString();
            button1.Enabled = true;
            button2.Enabled = false;
            MessageBox.Show($"Количество найденных = {foundCount} и общее количество файлов = {totalCount}");
        }
    }

    // Обработчик кнопки "Остановить" (button2)
    private void button2_Click(object sender, EventArgs e)
    {
        cts?.Cancel();
    }

    // Обработчик Timer (timer1) — в Properties выстави Interval = 100
    private void timer1_Tick(object sender, EventArgs e)
    {
        label3.Text = stopwatch.Elapsed.ToString();
    }

    void SearchDirectory(string dir, string ext, TreeNode parentNode, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        string[] subDirs;
        string[] files;
        try
        {
            subDirs = Directory.GetDirectories(dir);
            files = Directory.GetFiles(dir);
        }
        catch (UnauthorizedAccessException) { return; }
        catch (IOException) { return; }

        foreach (var file in files)
        {
            token.ThrowIfCancellationRequested();
            totalCount++;

            bool matches = string.Equals(Path.GetExtension(file), ext, StringComparison.OrdinalIgnoreCase);
            if (matches)
            {
                foundCount++;
                string fileName = Path.GetFileName(file);
                treeView1.Invoke((MethodInvoker)(() =>
                {
                    var fileNode = new TreeNode(fileName) { Tag = file, ForeColor = Color.DarkGreen };
                    parentNode.Nodes.Add(fileNode);
                }));
            }
        }

        foreach (var sub in subDirs)
        {
            token.ThrowIfCancellationRequested();
            TreeNode? subNode = null;
            string subName = Path.GetFileName(sub);
            treeView1.Invoke((MethodInvoker)(() =>
            {
                subNode = new TreeNode(subName) { Tag = sub };
                parentNode.Nodes.Add(subNode);
            }));
            SearchDirectory(sub, ext, subNode!, token);
        }
    }
}
}

using System.Diagnostics;

public static class CommandTool
{

    public static void ProcessCommand(string command, string argument)
    {
        ProcessStartInfo info = new(command);
        //启动应用程序时要使用的一组命令行参数。
        info.Arguments = argument;
        //是否弹窗
        info.CreateNoWindow = true;
        //获取或设置指示不能启动进程时是否向用户显示错误对话框的值。
        info.ErrorDialog = true;
        //获取或设置指示是否使用操作系统 shell 启动进程的值。
        info.UseShellExecute = false;

        if (info.UseShellExecute)
        {
            info.RedirectStandardOutput = false;
            info.RedirectStandardError = false;
            info.RedirectStandardInput = false;
        }
        else
        {
            info.RedirectStandardOutput = true; //获取或设置指示是否将应用程序的错误输出写入 StandardError 流中的值。
            info.RedirectStandardError = true; //获取或设置指示是否将应用程序的错误输出写入 StandardError 流中的值。
            info.RedirectStandardInput = true;//获取或设置指示应用程序的输入是否从 StandardInput 流中读取的值。
            info.StandardOutputEncoding = System.Text.Encoding.UTF8;
            info.StandardErrorEncoding = System.Text.Encoding.UTF8;
        }
        UnityEngine.Debug.Log($"执行命令: {command} {info.Arguments}");
        //启动(或重用)此 Process 组件的 StartInfo 属性指定的进程资源，并将其与该组件关联。
        Process process = Process.Start(info);
        //StandardInput：获取用于写入应用程序输入的流。
        //将字符数组写入文本流，后跟行终止符。
        // process.StandardInput.WriteLine(argument);
        //获取或设置一个值，该值指示 StreamWriter 在每次调用 Write(Char) 之后是否都将其缓冲区刷新到基础流。
        process.StandardInput.AutoFlush = true;

        if (!info.UseShellExecute)
        {
            string output = process.StandardOutput.ReadToEnd();
            string outputError = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(output))
            {
                UnityEngine.Debug.Log(output);
            }
            if (!string.IsNullOrEmpty(outputError))
            {
                UnityEngine.Debug.Log(outputError);
            }
        }

        process.WaitForExit();
        //关闭
        process.Close();
    }
}
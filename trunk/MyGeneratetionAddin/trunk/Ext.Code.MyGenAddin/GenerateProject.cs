using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Legendigital.Code.MyGenAddin
{
    public partial class GenerateProject : Form
    {
        public GenerateProject()
        {
            InitializeComponent();
        }

        private List<string> needToReplaceFileType = new List<string>() { ".CS", ".ASAX", ".CSPROJ", ".ASPX", ".ASCX", ".Master" };

        public const string TemplateTagProjectName = "$safeprojectname$";

        private void btnOK_Click(object sender, EventArgs e)
        {
            string filePath = @"E:\New Folder (4)\WebAdminTemplate.zip";

            string exDirectoryPath = @"E:\New Folder (4)\WebAdminTemplate";

            string generateDirectoryPath = @"E:\New Folder (4)\Test";

            string projectName = @"TGSProjectManage";

            List<string> allfiles = GetAllFile(exDirectoryPath);

            foreach (string file in allfiles)
            {
                string fileName = Path.GetFileName(file);
                string dirName = Path.GetDirectoryName(file);
                string relateDirName = dirName.Replace(exDirectoryPath, "");
                if(!relateDirName.EndsWith(@"\"))
                {
                    relateDirName = relateDirName + @"\";
                }
                if (!relateDirName.StartsWith(@"\"))
                {
                    relateDirName = @"\" + relateDirName;
                }
                if (needToReplaceFileType.Contains(Path.GetExtension(file).ToUpper()))
                {
                    ProcesstemplateFile(generateDirectoryPath, relateDirName, file, fileName, projectName);
                }
                else
                {
                    MoveFile(generateDirectoryPath, relateDirName, file, fileName);
                }
            }

            MessageBox.Show("Ok");

        }

        private void ProcesstemplateFile(string newDirectoryPath, string relateDirName, string oldFilePath, string fileName,string projectName)
        {
            string fileContent = ReadFileContent(oldFilePath);

            fileContent = fileContent.Replace(TemplateTagProjectName, projectName);

            string newPath = CombineDirectory(newDirectoryPath, relateDirName);

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            WriteFileContent(Path.Combine(newPath, fileName), fileContent);
        }

        private void MoveFile(string newDirectoryPath, string relateDirName, string oldFilePath,string fileName)
        {
            string newPath = CombineDirectory(newDirectoryPath, relateDirName);

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            File.Copy(oldFilePath, Path.Combine(newPath, fileName), true);

        }

        private string CombineDirectory(string path1, string path2)
        {
            if (!path1.EndsWith(@"\"))
            {
                path1 = path1 + @"\";
            }
            if (!path2.StartsWith(@"\"))
            {
                path2 = @"\" + path2;
            }

            return (path1 + path2).Replace(@"\\", @"\");
        }

        private List<string> GetAllFile(string directoryPath)
        {
            List<string> findfiles = new List<string>();

            foreach (string filePath in Directory.GetFiles(directoryPath, "*.*",SearchOption.AllDirectories))
            {
                findfiles.Add(filePath);
            }

            return findfiles;
        }

        private string ReadFileContent(string filePath)
        {
            StringBuilder sbFileContent = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        sbFileContent.AppendLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                throw new Exception("The file could not be read:"+e.Message,e);
            }
            return sbFileContent.ToString();
        }

        private void WriteFileContent(string filePath,string content)
        {
            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
            }

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(content);
            }

        }




    }
}

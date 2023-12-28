using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileEncrypter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    inputDirectory.Text = selectedFolder;

                    EncryptFolder(selectedFolder);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    inputDirectory2.Text = selectedFolder;

                    DecryptFiles(selectedFolder);
                }
            }
        }

        public void DecryptFiles(string folderPath)
        {
            try
            {
                string decryptedDirectory = folderPath + "_Decrypted";

                if (!Directory.Exists(decryptedDirectory))
                {
                    Directory.CreateDirectory(decryptedDirectory);
                    outputDirectory2.Text = decryptedDirectory;
                }

                Queue<string> directoriesToProcess = new Queue<string>();
                directoriesToProcess.Enqueue(folderPath);

                int totalFiles = CountFiles(folderPath);
                decryptingProgressBar.Maximum = totalFiles;
                decryptingProgressBar.Value = 0;

                while (directoriesToProcess.Count > 0)
                {
                    string currentDirectory = directoriesToProcess.Dequeue();
                    string relativePath = currentDirectory.Substring(folderPath.Length).Trim(Path.DirectorySeparatorChar);

                    string decryptedSubdirectory = Path.Combine(decryptedDirectory, relativePath);

                    if (!Directory.Exists(decryptedSubdirectory))
                    {
                        Directory.CreateDirectory(decryptedSubdirectory);
                    }

                    string[] files = Directory.GetFiles(currentDirectory);

                    foreach (var file in files)
                    {
                        string fileName = Path.GetFileName(file);

                        fileName = fileName.Substring(0, fileName.Length - ".png".Length);

                        string encryptedContent = ConvertToString(Path.GetFullPath(file));
                        string decryptedContent = Decrypt(encryptedContent, keyInput2.Text);

                        textBox4.Text = decryptedContent;

                        string decryptedFilePath = Path.Combine(decryptedSubdirectory, fileName);
                        File.WriteAllText(decryptedFilePath, decryptedContent);

                        decryptingProgressBar.Value++;
                        Application.DoEvents();
                    }

                    string[] subDirectories = Directory.GetDirectories(currentDirectory);
                    foreach (var subDirectory in subDirectories)
                    {
                        directoriesToProcess.Enqueue(subDirectory);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void EncryptFolder(string folderPath)
        {
            try
            {
                string encryptedDirectory = folderPath + "_Encrypted";

                if (!Directory.Exists(encryptedDirectory))
                {
                    Directory.CreateDirectory(encryptedDirectory);
                    outputDirectory.Text = encryptedDirectory;
                }

                Queue<string> directoriesToProcess = new Queue<string>();
                directoriesToProcess.Enqueue(folderPath);

                int totalFiles = CountFiles(folderPath);
                encryptingProgressBar.Maximum = totalFiles;
                encryptingProgressBar.Value = 0;

                while (directoriesToProcess.Count > 0)
                {
                    string currentDirectory = directoriesToProcess.Dequeue();
                    string relativePath = currentDirectory.Substring(folderPath.Length).Trim(Path.DirectorySeparatorChar);

                    string encryptedSubdirectory = Path.Combine(encryptedDirectory, relativePath);

                    if (!Directory.Exists(encryptedSubdirectory))
                    {
                        Directory.CreateDirectory(encryptedSubdirectory);
                    }

                    string[] files = Directory.GetFiles(currentDirectory);

                    foreach (var file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        string fileContent = File.ReadAllText(file);

                        string encryptedContent = Encrypt(fileContent, keyInput.Text);

                        Image image = ConvertToImage(fileContent);
                        pictureBox1.Image = image;

                        Image encryptedImage = ConvertToImage(encryptedContent);

                        string imagePath = Path.Combine(encryptedSubdirectory, fileName + ".png");
                        encryptedImage.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

                        encryptingProgressBar.Value++;
                        Application.DoEvents();
                    }

                    string[] subDirectories = Directory.GetDirectories(currentDirectory);
                    foreach (var subDirectory in subDirectories)
                    {
                        directoriesToProcess.Enqueue(subDirectory);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private int CountFiles(string folderPath)
        {
            return Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).Length;
        }

        public static Image ConvertToImage(string input)
        {
            int maxWidth = 0;
            foreach (char c in input)
            {
                int charCode = (int)c;
                if (charCode > maxWidth)
                {
                    maxWidth = charCode;
                }
            }

            int height = input.Length;
            int width = maxWidth + 1;

            Bitmap bitmap = new Bitmap(width, height);

            for (int i = 0; i < input.Length; i++)
            {
                int charCode = (int)input[i];
                int x = charCode;
                int y = i;

                if (x < width && y < height)
                {
                    bitmap.SetPixel(x, y, Color.Black);
                }
            }

            return bitmap;
        }

        public static string ConvertToString(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException("Image file not found.", imagePath);
            }

            Bitmap bitmap = new Bitmap(imagePath);
            StringBuilder result = new StringBuilder();

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    
                    if (pixelColor.A == 255)
                    {
                        char charCode = (char)x;
                        result.Append(charCode);
                    }
                }
            }

            return result.ToString();
        }

        public static string Decrypt(string encryptedString, string keyString)
        {
            using (Aes aesAlg = Aes.Create())
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedString);
                byte[] iv = new byte[aesAlg.BlockSize / 8];
                byte[] cipherText = new byte[encryptedBytes.Length - iv.Length];

                Buffer.BlockCopy(encryptedBytes, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(encryptedBytes, iv.Length, cipherText, 0, cipherText.Length);

                aesAlg.Key = GenerateKey(keyString);
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string Encrypt(string inputString, string keyString)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GenerateKey(keyString);
                aesAlg.GenerateIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(inputString);
                        }
                    }

                    byte[] iv = aesAlg.IV;
                    byte[] encryptedBytes = msEncrypt.ToArray();

                    byte[] result = new byte[iv.Length + encryptedBytes.Length];
                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                    Buffer.BlockCopy(encryptedBytes, 0, result, iv.Length, encryptedBytes.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }

        private static byte[] GenerateKey(string keyString)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(keyString));
            }
        }

        private void OpenDirectory(string directoryPath)
        {
            if (System.IO.Directory.Exists(directoryPath))
            {
                Process.Start("explorer.exe", directoryPath);
            }
            else
            {
                MessageBox.Show("Directory does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inputDirectory_Click(object sender, EventArgs e)
        {
            OpenDirectory(inputDirectory.Text);
        }

        private void outputDirectory_Click(object sender, EventArgs e)
        {
            OpenDirectory(outputDirectory.Text);
        }

        private void inputDirectory2_Click(object sender, EventArgs e)
        {
            OpenDirectory(inputDirectory2.Text);
        }

        private void outputDirectory2_Click(object sender, EventArgs e)
        {
            OpenDirectory(outputDirectory2.Text);
        }
    }
}

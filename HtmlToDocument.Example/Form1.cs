using HtmlToDocument.Enums;
using HtmlToDocument.Models;

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HtmlToDocument.Example
{
    public partial class Form1 : Form
    {
        private DocumentConvert _documentConvert;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTypeDocument.DataSource = Enum.GetValues(typeof(TypeDocument));
            cmbOrientation.DataSource = Enum.GetValues(typeof(PageOrientation));
        }

        private void BtBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "HTML файл (*.html)|*.html";
                txtPathHtml.Text = dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : string.Empty;
            }
        }

        private void BtConvert_Click(object sender, EventArgs e)
        {
            var path = txtPathHtml.Text;

            if (File.Exists(path) && Path.GetExtension(path).ToLower() == ".html")
            {
                BuildConvert(path);
            }
            else
            {
                MessageBox.Show("Не верный тип файла");
            }
        }

        private void BuildConvert(string path)
        {
            var typeDOcument = (TypeDocument)cmbTypeDocument.SelectedIndex;
            var typeOrientation = (PageOrientation)cmbOrientation.SelectedIndex;

            var option = new PrintOptions()
            {
                Font = new Font()
                {
                    Size = 12
                },
                PageOrientation = typeOrientation
            };

            var outPath = Path.GetDirectoryName(path) + ".docx";

            try
            {
                Convert(path, outPath, typeDOcument, option);

                if (File.Exists(outPath))
                {
                    Process.Start(outPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Convert(string htmlPath, string outPath, TypeDocument typeDocument, PrintOptions printOptions)
        {
            _documentConvert = _documentConvert ?? new DocumentConvert();
            _documentConvert.Convert(htmlPath, outPath, typeDocument, printOptions);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace BookSeller
{
    public partial class frmBookViewer : Form
    {
        string Old_ISBN;    //Needed for UpdateSQL statement

        public enum SaveOrUpdateDelete
        {
            Save,
            Update,
            Delete
        };

        public frmBookViewer()
        {
            InitializeComponent();
        }

        private void frmBookViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void ListBooksOrFilter(bool filter)
        {
            listBoxBooks.Items.Clear();
            Books[] ListedBooks;
            
            if (filter)
                new BookHandler(out ListedBooks, filterComboBox.Text, FilterTextBox.Text);
            else
                new BookHandler(out ListedBooks);

            foreach (Books Book in ListedBooks)
            {
                if (Book == null) 
                    break;
                listBoxBooks.Items.Add(Book);
            }

            listBoxBooks.SelectedIndex = 0;
        }

        private void listBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coverPictureBox.Image != null)
            {
                coverPictureBox.Image.Dispose();
            }

            FileStream FS1 = new FileStream("image.jpeg", FileMode.Create);
            Books book = listBoxBooks.SelectedItem as Books;
            titleTextBox.Text = book.Title;
            authorTextBox.Text = book.Author;
            isbnTextBox.Text = book.ISBN;
            yearTextBox.Text = book.Year;
            pagesTextBox.Text = book.Pages.ToString();
            priceTextBox.Text = book.Price.ToString("c");
            instocktextBox.Text = book.In_Stock.ToString();

            if (book.In_Stock == 0)
            {
                outofstockpicturebox.Visible = true;
            }
            else
            {
                outofstockpicturebox.Visible = false;
            }

            hiredtextBox.Text = book.Hired_Out.ToString();
            FS1.Write(book.pic, 0, book.pic.Length);
            coverPictureBox.Image = Image.FromStream(FS1);
            coverPictureBox.Refresh();
            Old_ISBN = isbnTextBox.Text;
            FS1.Close();
        }

        byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private bool SaveOrUpdateOrDeleteSQL(SaveOrUpdateDelete saveOrUpdateDelete)
        {
            bool success;

            if (coverPictureBox.ImageLocation == null)
            {
                coverPictureBox.ImageLocation = Application.StartupPath + "\\No_Image.jpeg";
            }

            Books BookInfo = new Books
            {
                Title = titleTextBox.Text,
                Author = authorTextBox.Text,
                ISBN = isbnTextBox.Text,
                Year = yearTextBox.Text,
                Pages = int.Parse(pagesTextBox.Text),
                Price = decimal.Parse(priceTextBox.Text, NumberStyles.Any),
                pic = ReadFile(coverPictureBox.ImageLocation), 
                In_Stock = int.Parse(instocktextBox.Text),
                Hired_Out = int.Parse(hiredtextBox.Text),
            };

            new BookHandler(BookInfo, saveOrUpdateDelete, Old_ISBN, out success);
            return success;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files (JPEG,GIF,BMP)|*.jpg;*.jpeg;*.gif;*.bmp|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF Files(*.gif)|*.gif|BMP Files(*.bmp)|*.bmp";
            DialogResult dlgRes = dlg.ShowDialog();

            if (dlgRes != DialogResult.Cancel)
            {
                coverPictureBox.ImageLocation = dlg.FileName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add Book")
            {
                var bmp = new Bitmap(BookSeller.Properties.Resources.no_image);
                bmp.Save("No_Image.jpeg", System.Drawing.Imaging.ImageFormat.Gif);
                Bitmap No_Image = new Bitmap("No_Image.jpeg");

                if (coverPictureBox.Image != null)
                {
                    coverPictureBox.Image = No_Image;
                    coverPictureBox.Refresh();
                }

                titleTextBox.Clear();
                authorTextBox.Clear();
                isbnTextBox.Clear();
                pagesTextBox.Clear();
                yearTextBox.Clear();
                priceTextBox.Clear();
                instocktextBox.Text = "1";
                hiredtextBox.Text = "0";
                btnAdd.Text = "Save";
                btnDone.Text = "Cancel";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                EditOptionsGroupBox.Visible = true;

            }
            else
            {
                if (DataValidate())
                    if (SaveOrUpdateOrDeleteSQL(SaveOrUpdateDelete.Save))
                    {
                        MessageBox.Show(titleTextBox.Text + " has been saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListBooksOrFilter(false);
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        EditOptionsGroupBox.Visible = false;
                        btnAdd.Text = "Add Book";
                    }
            }
        }

        private bool DataValidate()
        {
            if (titleTextBox.Text == "")
            {
                MessageBox.Show("No Title has been given");
                titleTextBox.Focus();
                return false;
            }
            else if (authorTextBox.Text == "")
            {
                MessageBox.Show("No Author has been given");
                authorTextBox.Focus();
                return false;
            }
            else if (isbnTextBox.Text == "")
            {
                MessageBox.Show("No ISBN has been given");
                isbnTextBox.Focus();
                return false;
            }
            else if (pagesTextBox.Text == "")
            {
                MessageBox.Show("No Pages number has been given");
                pagesTextBox.Focus();
                return false;
            }
            else if (yearTextBox.Text == "")
            {
                MessageBox.Show("No Year has been given");
                yearTextBox.Focus();
                return false;
            }
            else if (instocktextBox.Text == "")
            {
                MessageBox.Show("No Stock count has been given");
                instocktextBox.Focus();
                return false;
            }
            else if (hiredtextBox.Text == "")
            {
                MessageBox.Show("No Hired count has been given");
                hiredtextBox.Focus();
                return false;
            }
            else if (priceTextBox.Text == "")
            {
                MessageBox.Show("No Price has been given");
                priceTextBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValidate())
            {
                if (coverPictureBox.ImageLocation == null)
                    coverPictureBox.ImageLocation = "image.jpeg";

                if (SaveOrUpdateOrDeleteSQL(SaveOrUpdateDelete.Update))
                {
                    MessageBox.Show(titleTextBox.Text + " has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListBooksOrFilter(false);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditOptionsGroupBox.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnShowFilter_Click(object sender, EventArgs e)
        {
            FilterGroupBox.Visible = true;
            filterComboBox.SelectedIndex = 0;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ListBooksOrFilter(true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListBooksOrFilter(false);
            FilterGroupBox.Visible = false;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (btnDone.Text == "Cancel")
            {
                EditOptionsGroupBox.Visible = false;
                ListBooksOrFilter(false);
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnDone.Text = "Done";
                btnAdd.Text = "Add Book";
            }
            else
            {
                FilterGroupBox.Visible = false;
                EditOptionsGroupBox.Visible = false;
                btnRemove.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SaveOrUpdateOrDeleteSQL(SaveOrUpdateDelete.Delete))
            {
                MessageBox.Show(titleTextBox.Text + " has been Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListBooksOrFilter(false);
            }
        }
    }
}

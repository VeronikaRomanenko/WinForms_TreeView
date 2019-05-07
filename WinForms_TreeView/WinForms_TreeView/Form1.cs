using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_TreeView
{
    public partial class Form1 : Form
    {
        TreeView tree = null;
        ImageList gallery = null;
        ListBox listBox = null;
        public Form1()
        {
            InitializeComponent();
            this.SetBounds(300, 300, 600, 1000);
            tree = new TreeView();
            this.Controls.Add(tree);
            tree.SetBounds(300, 30, 300, 400);
            //создаем узел дерева
            TreeNode node1 = new TreeNode("Новый узел");
            tree.Nodes.Add(node1);
            //инициализация галереи картинок
            try
            {
                gallery = new ImageList();
                tree.ImageList = gallery;
                gallery.ImageSize = new Size(50, 50);
                Bitmap bmp = new Bitmap("");//картинка *.bmp
                gallery.Images.Add(bmp);
                bmp = new Bitmap("");
                gallery.Images.Add(bmp);
                node1 = new TreeNode("Изображение", 1, 0);
                tree.Nodes.Add(node1);
                node1 = new TreeNode("Изображение", 0, 1);
                tree.Nodes.Add(node1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tree.DoubleClick += Tree_DoubleClick;
            listBox = new ListBox();
            listBox.SetBounds(20, 30, 250, 300);
            this.Controls.Add(listBox);

            TreeNode[] treenodes =
            {
                new TreeNode("iPhone 5s"),
                new TreeNode("iPhone 6s")
            };

            TreeNode[] treenodes2 =
            {
                new TreeNode("Mi mix 2"),
                new TreeNode("Mi max 3")
            };

            TreeNode apple = new TreeNode("Apple");
            treeView1.Nodes.Add(apple);
            apple.Nodes.AddRange(treenodes);

            TreeNode xiaomi = new TreeNode("Apple");
            treeView1.Nodes.Add(apple);
            apple.Nodes.AddRange(treenodes);
            //обход дерева
            recurse_list(treeView1.Nodes);
        }

        private void recurse_list(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                listBox.Items.Add(node.Text);
                if (node.Nodes.Count > 0)
                {
                    recurse_list(node.Nodes);
                }
            }
        }

        private void Tree_DoubleClick(object sender, EventArgs e)
        {
            TreeView tv = sender as TreeView;
            tree.Nodes.Remove(tv.SelectedNode);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class GPACalculator : Form
    {
        private int Credits;
        private double Points;
        private double GPA = 0.0;
       public GPACalculator()
        {
            InitializeComponent();
            gradeBox.Items.Add("A+");
            gradeBox.Items.Add("A");
            gradeBox.Items.Add("A-");
            gradeBox.Items.Add("B+");
            gradeBox.Items.Add("B");
            gradeBox.Items.Add("B-");
            gradeBox.Items.Add("C+");
            gradeBox.Items.Add("C");
            gradeBox.Items.Add("C-");
            gradeBox.Items.Add("D+");
            gradeBox.Items.Add("D");
            gradeBox.Items.Add("D-");
            gradeBox.Items.Add("F");
            deleteButton.Enabled = false;
            deleteButton.Visible = false;
            updateButton.Enabled = false;
            updateButton.Visible = false;
            GPA = 0.0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = GPA.ToString("0.00");
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Class current = (Class)classList.SelectedItem;
                if (current != null)
                {
                    Credits -= current.getCredit();
                    Points -= current.getPoints() * current.getCredit();
                    classList.Items.Remove(classList.SelectedItem);
                    if ((Points == 0) && (Credits == 0))
                    {
                        GPA = 0.0;
                    }
                    else
                    {
                        GPA = Points / Credits;
                    }
                    label5.Text = string.Format(GPA.ToString("0.00"));
                    nameBox.Text = null;
                    creditBox.Text = null;
                    gradeBox.Text = null;

                }
            }
            catch
            {
                return;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = nameBox.Text;

                if (name.Length < 8)
                {
                    name.PadLeft(8);
                }
                Class newClass = new Class(name, gradeBox.Text, int.Parse(creditBox.Text));
                Credits += newClass.getCredit();
                Points += newClass.getPoints() * newClass.getCredit();

                update();
                classList.Items.Add(newClass);
             } catch {
                return;
            }
        }

        private void classList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (classList.SelectedItem == null)
                {
                    return;
                }
                else
                {
                    deleteButton.Enabled = true;
                    deleteButton.Visible = true;
                    updateButton.Enabled = true;
                    updateButton.Visible = true;
                    Class current = (Class)classList.SelectedItem;
                    nameBox.Text = current.getName();
                    creditBox.Text = current.getCredit().ToString();

                    switch (current.getGrade())
                    {
                        case "A+":
                            gradeBox.SelectedItem = gradeBox.Items[0];
                            break;
                        case "A":
                            gradeBox.SelectedItem = gradeBox.Items[1];
                            break;
                        case "A-":
                            gradeBox.SelectedItem = gradeBox.Items[2];
                            break;
                        case "B+":
                            gradeBox.SelectedItem = gradeBox.Items[3];
                            break;
                        case "B":
                            gradeBox.SelectedItem = gradeBox.Items[4];
                            break;
                        case "B-":
                            gradeBox.SelectedItem = gradeBox.Items[5];
                            break;
                        case "C+":
                            gradeBox.SelectedItem = gradeBox.Items[6];
                            break;
                        case "C":
                            gradeBox.SelectedItem = gradeBox.Items[7];
                            break;
                        case "C-":
                            gradeBox.SelectedItem = gradeBox.Items[8];
                            break;
                        case "D+":
                            gradeBox.SelectedItem = gradeBox.Items[9];
                            break;
                        case "D":
                            gradeBox.SelectedItem = gradeBox.Items[10];
                            break;
                        case "D-":
                            gradeBox.SelectedItem = gradeBox.Items[11];
                            break;
                        case "F":
                            gradeBox.SelectedItem = gradeBox.Items[12];
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            catch
            {
                return;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (classList.SelectedItem == null)
                {
                    return;
                }
                else
                {
                    Class current = (Class)classList.SelectedItem;
                    Points -= current.getPoints() * current.getCredit();
                    Credits -= current.getCredit();
                    current.setCredit(int.Parse(creditBox.Text));
                    current.setName(nameBox.Text);
                    current.setGrade(gradeBox.Text);
                    Points += current.getPoints() * current.getCredit();
                    Credits += current.getCredit();
                    int index = classList.SelectedIndex;
                    classList.Items.RemoveAt(index);
                    classList.Items.Insert(index, current);
                    update();

                }
            }
            catch
            {
                return;
            }
        }

        private void clear()
        {
            nameBox.Text = null;
            creditBox.Text = null;
            gradeBox.Text = null;
            classList.SelectedItem = null;
            deleteButton.Enabled = false;
            deleteButton.Visible = false;
            updateButton.Enabled = false;
            updateButton.Visible = false;
        }
        
        private void update()
        {
            nameBox.Text = null;
            creditBox.Text = null;
            gradeBox.Text = null;
            classList.SelectedItem = classList.SelectedItem;
            deleteButton.Enabled = false;
            deleteButton.Visible = false;
            updateButton.Enabled = false;
            updateButton.Visible = false;
            if (Credits != 0)
            {
                GPA = Points / Credits;
            }
            else
            {
                GPA = 0;
            }
            label5.Text = GPA.ToString("0.00");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void emptyButton_Click(object sender, EventArgs e)
        {
            Points = 0;
            Credits = 0;
            classList.Items.Clear();
            update();

        }
    }
}

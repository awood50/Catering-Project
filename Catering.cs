/*Name:Andrew Wood
 * Date: 4/8/19
 * Purpose: Code class to control the Catering Design form
 */
using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;



namespace Catering
{
    public partial class Catering : Form
    {
        public Catering()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            String place1 = "";//string variable for holding order information
            String place2 = "";//string variable for holding order information
            String place3 = "";//string variable for holding order information

            int holder1 = 0;//integer variables for helping calculate order information
            int cost = 0;//integer variables for helping calculate order information
            int other = 0;//integer variables for helping calculate order information

            place1 = textBox1.Text;//setting string variable equal to textbox values
            place2 = textBox2.Text;//setting string variable equal to textbox values


            if (Regex.IsMatch(textBox3.Text, @"[a-zA-Z]"))//Learned about RegEx in Software Engineering with Ruby and researched how to use it in C#. It is easy to use it to see if the information entered is actually a number
            {
                cost = 0; //cost will be set to null because there is not a proper guest value entered
                MessageBox.Show("Price is 0, because the value " + "entered for the number of guests is not actually a number");//message box to show that there was not a proper value entered
            }

            else//else if there was actually a number of guests entered
            {
                other = Int32.Parse(textBox3.Text); //this statement takes the number of the guests that is in the textbox3
                cost = other * 35;//the cost is multiplied by $35 per guest
            }

            String dessert1 = comboBox1.Text;//dessert selection set to the combobox

            if (checkBox1.Checked)//if the box is checked
            {
                holder1++;//holder is incremented in order to check for more than two choices
                place3 = place3 + " Spaghetti";//sets the current value of the choice to whatever is checked
            }

            if (checkBox2.Checked)
            {
                holder1++;//holder is incremented in order to check for more than two choices
                place3 = place3 + " Hamburger";//sets the current value of the choice to whatever is checked
            }

            if (checkBox3.Checked)
            {
                holder1++;//holder is incremented in order to check for more than two choices
                place3 = place3 + " Pork Chops";//sets the current value of the choice to whatever is checked
            }

            if (checkBox4.Checked)
            {
                holder1++;//holder is incremented in order to check for more than two choices
                place3 = place3 + " Grilled Chicken";//sets the current value of the choice to whatever is checked
            }

            if (holder1 > 2)//if the holder variable has more than two selected

            {
                checkBox1.Checked = false;//all values are set to false and are not checked
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                MessageBox.Show("Only two dishes can be chosen");//message box to tell the user what happened
            }

            else//if all is successful
            {
                FileStream fileEvent = new FileStream("Event.txt", FileMode.Create);//file stream for sending of file
                StreamWriter streamEvent = new StreamWriter(fileEvent);//stream writer to write the file
                streamEvent.WriteLine(textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + comboBox2.Text +" " + place3 + " " + comboBox1.Text + " " + cost);//streamwriter writing the contents to the file
                MessageBox.Show("Data written to file");
                fileEvent.Close();//close statements
                //streamEvent.Close();
            }





        }
    }
}
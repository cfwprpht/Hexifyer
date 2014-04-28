using System;
using System.IO;
using System.Windows.Forms;

namespace Hexifyer
{
    public partial class Hexifyer : Form
    {
        static string result = "ERROR!";
        static string[] toHexifyArray;
        static string thisFile;
        static string toSplit;
        static string splitSwap;
        string bufferA;
        string bufferB;
        static int x = 0;
        static int y = 4;
        static string newResult;
        static string[] lowerCase = new string[6] { "a", "b", "c", "d", "e", "f", };
        static string[] upperCase = new string[6] { "A", "B", "C", "D", "E", "F", };

        public Hexifyer()
        {
            InitializeComponent();
        }

        private void textOpen_DragEnter(object sender, DragEventArgs e)
        {
            //Makes sure that the user is dropping a file, not text
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                //Allows them to continue
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textOpen_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                textOpen.Text = file.ToString();
            }
        }

        private void Hexifyer_DragEnter(object sender, DragEventArgs e)
        {
            //Makes sure that the user is dropping a file, not text
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                //Allows them to continue
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Hexifyer_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                textOpen.Text = file.ToString();
            }
        }

        private void StartUpCheck(string pathToConf)
        {
            if (File.Exists(pathToConf) == true)
            {
                int s = File.ReadAllLines(pathToConf).Length;
                string[] buffer = File.ReadAllLines(pathToConf);

                if (s >= 1)
                {
                    string path = buffer[0].Replace("staticFile=", "");
                    if (path != "")
                    {
                        textOpen.Text = path;
                    }
                    else
                    {
                        textOpen.Text = "Open File to Hexify...";
                    }
                }
                if (s >= 2)
                {
                    string allign = buffer[1].Replace("allignTo16=", "");
                    if (allign == "true")
                    {
                        check16.Checked = true;
                    }
                    else
                    {
                        check16.Checked = false;
                    }
                }
                if (s >= 3)
                {
                    string lo2Up = buffer[2].Replace("lowerToUpper=", "");
                    if (lo2Up == "true")
                    {
                        checkaA.Checked = true;
                    }
                    else
                    {
                        checkaA.Checked = false;
                    }
                }
                if (s >= 4)
                {
                    string nNF = buffer[3].Replace("NoNewFile=", "");
                    if (nNF == "true")
                    {
                        checkNNF.Checked = true;
                    }
                    else
                    {
                        checkNNF.Checked = false;
                    }
                }
                if (s >= 5)
                {
                    string deHe = buffer[4].Replace("deHexify=", "");
                    if (deHe == "true")
                    {
                        checkDEH.Checked = true;
                    }
                    else
                    {
                        checkDEH.Checked = false;
                    }
                }
                if (s == 6)
                {
                    string close = buffer[5].Replace("closeApp=", "");
                    if (close == "true")
                    {
                        checkClose.Checked = true;
                    }
                    else
                    {
                        checkClose.Checked = false;
                    }
                }
            }
        }

        private void Hexifyer_Load(object sender, EventArgs e)
        {
            buttonHexify.Enabled = false;
            textOpen.DragEnter += new DragEventHandler (textOpen_DragEnter);
            textOpen.DragDrop += new DragEventHandler(textOpen_DragDrop);
            this.DragEnter += new DragEventHandler(Hexifyer_DragEnter);
            this.DragDrop += new DragEventHandler(Hexifyer_DragDrop);

            StartUpCheck("hexifyer.conf");
        }

        private string LowerToUpperCase(string line)
        {
            string buffer = line;
            for (int i = 0; i < 6; i++)
            {
                newResult = buffer.Replace(lowerCase[i], upperCase[i]);
                buffer = newResult;
            }
            return newResult;
        }

        private string Hexify(string fileToUse)
        {
            // What's the file size?
            FileInfo fileInfo = new FileInfo(fileToUse);
            long n = fileInfo.Length;

            // Do we use a empty File?
            if (n == 0)
            {
                return result;
            }

            // Read up the Input File into a String Array
            toHexifyArray = File.ReadAllLines(fileToUse);

            // Shall we use the same file?
            if (checkNNF.Checked == true)
            {
                // Delete the Input file and new create it
                File.Delete(fileToUse);
                File.Create(fileToUse).Close();
                thisFile = fileToUse;
            }
            else
            {
                // Create the new empty file to fil up
                File.Create(textOpen.Text + "_hexifyed.txt").Close();
                thisFile = textOpen.Text + "_hexifyed.txt";
            }

            // Do we want to allign the line(s) to 16 bytes?
            if (check16.Checked == true)
            {
                foreach (string line in toHexifyArray)
                {
                    int d;
                    if ((d = line.Length) > 32)
                    {
                        // Write the Line that is higher then 32
                        int u = 0;
                        splitSwap = line;

                        while(d != 0)
                        {
                            u += 32;
                            toSplit = splitSwap.Insert(u, "n");
                            u += 1;

                            if ((d -= 32) < 32)
                            {
                                // Finally Split the 16 byte alligned text string into a Array
                                string[] splitLine = toSplit.Split(new string[] {"n"}, StringSplitOptions.None);

                                // Finally Write the 16 byte alligned string Array
                                File.AppendAllLines(thisFile, splitLine);
                                File.AppendAllText(thisFile, "\n");
                            }
                            else
                            {
                                splitSwap = toSplit;
                            }
                        }
                    }
                    else if (d <= 32 && d != 0)
                    {
                        // Write the Line that is equal or smaller then 16 bytes
                        File.AppendAllText(thisFile, line + "\n\n");
                    }
                    else
                    {
                        // Write the empty Line
                        File.AppendAllText(thisFile, "\n\n");
                    }
                }

                toHexifyArray = File.ReadAllLines(thisFile);
                File.Delete(thisFile);
                File.Create(thisFile).Close();
            }

            // For every Line in the String Array do..
            foreach (string line in toHexifyArray)
            {
                // We reset all integer's to the base values
                x = 0;
                y = 4;
                int i;
                int d;

                // Well when i need to explain that then your wrong here...
                bufferA = "";
                bufferB = "";

                // Do we want to convert from lower to upper case?
                if (checkaA.Checked == true)
                {
                    // The whole line will be converted from (a,b,c,d,e,f) 2 (A,B,C,D,E,F) before....
                    // ...we overload the string from our line into a new buffer so we can insert and swap the string to repeat the process the whole line long
                    bufferA = LowerToUpperCase(line);
                }
                else
                {
                    // We overload the string from our line into a new buffer so we can insert and swap the string to repeat the process the whole line long
                    bufferA = line;
                }

                // Do we use a empty Line?
                if ((d = bufferA.Length) != 0)
                {
                    // If no we set "i" to the length of the line and as long "i" isn't 0 we subtract 2 off it and repeat the process. Cause this is a loop and in every round we add "0x" & ", " to a pair of 2 Numbers till the whole line is worked down.
                    for (i = bufferA.Length; i > 0; i -= 2)
                    {
                        // Now we insert into our string and save the result to bufferB
                        bufferB = bufferA.Insert(x, "0x").Insert(y, ", ");

                        // To find the correct count to insert our "0x" & ", " we need to add + 6 to both pointer. Cause eg. we startet at pointer 0 for "0x" we wrote that, which will count in 2 then + the numbers eg. 45 result in 4 (like "0x45") at least we add ", " so again 4 + 2 = 6 (like "0x45, "). There for we add 6.
                        x += 6;
                        y += 6;

                        i -= 2;

                        // Have we reached the end of line? If not repeat the process.
                        if (i != 0)
                        {
                            // The overworked string from bufferB need to be overloaded back to bufferA so we can repeat and work down the whole line. Douring overloading, if we don't have reached the end of line we repeat the process of inserting.
                            bufferA = bufferB.Insert(x, "0x").Insert(y, ", "); ;

                            x += 6;
                            y += 6;
                        }
                        else
                        {
                            bufferA = bufferB;
                        }
                    }

                    // Finally we write the overworked line to file
                    File.AppendAllText(thisFile, bufferA + "\n");
                }
                else
                {
                    // If yes we add a empty Line
                    File.AppendAllText(thisFile, "\n");
                }
            }

            result = "Done!";
            return result;
        }

        private string DeHexify(string fileToUse)
        {
            // What's the file size?
            FileInfo fileInfo = new FileInfo(fileToUse);
            long n = fileInfo.Length;

            // Do we use a empty File?
            if (n == 0)
            {
                return result;
            }

            // Read up the Input File into a String Array
            toHexifyArray = File.ReadAllLines(fileToUse);

            // Shall we use the same file?
            if (checkNNF.Checked == true)
            {
                // Delete the Input file and new create it
                File.Delete(fileToUse);
                File.Create(fileToUse).Close();
                thisFile = fileToUse;
            }
            else
            {
                // Create the new empty file to fil up
                File.Create(textOpen.Text + "_hexifyed.txt").Close();
                thisFile = textOpen.Text + "_hexifyed.txt";
            }

            // For every Line in the String Array do..
            foreach (string line in toHexifyArray)
            {
                // Well when i need to explain that then your wrong here...
                string bufferA;
                string bufferB;

                // Do we want to convert from lower to upper case?
                if (checkaA.Checked == true)
                {
                    // The whole line will be converted from (a,b,c,d,e,f) 2 (A,B,C,D,E,F) before....
                    // ...we overload the string from our line into a new buffer so we can insert and swap the string to repeat the process the whole line long
                    bufferA = LowerToUpperCase(line);
                }
                else
                {
                    // We overload the string from our line into a new buffer so we can insert and swap the string to repeat the process the whole line long
                    bufferA = line;
                }

                // Do we use a empty Line?
                int d;
                if ((d = line.Length) != 0)
                {
                    // Now we insert into our string and save the result to bufferB
                    bufferB = bufferA.Replace("0x", "").Replace(", ", "");

                    // Finally we write the overworked line to file
                    File.AppendAllText(thisFile, bufferB + "\n");
                }
                else
                {
                    // If yes we add a empty Line
                    File.AppendAllText(thisFile, "\n");
                }
            }

            // Do we want to allign the line(s) to 16 bytes?
            if (check16.Checked == true)
            {
                toHexifyArray = File.ReadAllLines(thisFile);
                File.Delete(thisFile);
                File.Create(thisFile).Close();

                foreach (string line in toHexifyArray)
                {
                    int d;
                    if ((d = line.Length) > 32)
                    {
                        // Write the Line that is higher then 16
                        int u = 0;
                        string toSplit;
                        string splitSwap = line;

                        while (d != 0)
                        {
                            u += 32;
                            toSplit = splitSwap.Insert(u, "n");
                            u += 1;

                            if ((d -= 32) < 32)
                            {
                                // Finally Split the 16 byte alligned text string into a Array
                                string[] splitLine = toSplit.Split(new string[] {"n"}, StringSplitOptions.None);

                                // Finally Write the 16 byte alligned string Array
                                File.AppendAllLines(thisFile, splitLine);
                            }
                            else
                            {
                                splitSwap = toSplit;
                            }
                        }

                    }
                    else if (d <= 32 && d != 0)
                    {
                        // Write the Line that is equal or smaller then 16 bytes
                        File.AppendAllText(thisFile, line + "\n");
                    }
                    else
                    {
                        // Write the empty Line
                        File.AppendAllText(thisFile, "\n");
                    }
                }
            }

            result = "Done!";
            return result;
        }

        private void textOpen_TextChanged(object sender, EventArgs e)
        {
            if (textOpen.Text != "Open File to Hexify...")
            {
                buttonHexify.Enabled = true;
            }

            string str1 = textOpen.Text;
            string str2 = "hexifyer.conf";
            bool contains;

            if ((contains = str1.Contains(str2)))
            {
                StartUpCheck(textOpen.Text);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textOpen.Text = openFile.FileName;
                buttonHexify.Enabled = true;
            }
        }

        private void buttonHexify_Click(object sender, EventArgs e)
        {
            if (textOpen.Text != "Open File to Hexify...")
            {
                string retur;
                string method;
                if (checkDEH.Checked != true)
                {
                    retur = Hexify(textOpen.Text);
                    method = "Hexifyed!";
                }
                else
                {
                    retur = DeHexify(textOpen.Text);
                    method = "DeHexifyed!";
                }

                if (retur == "Done!")
                {
                    MessageBox.Show("Done!\nYour File would be successful " + method);
                    if (checkClose.Checked == true)
                    {
                        Application.Exit();
                    }
                }
                else if (retur == "ERROR!")
                {
                    MessageBox.Show("Nice Try ^^\nNext time don't feed me with a empty file....\nif you want to see any result :P");
                }
            }
        }
    }
}

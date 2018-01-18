using Hexifyer.Properties;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Hexifyer {
    public partial class Hexifyer : Form {
        static string result = "ERROR!";
        static string[] toHexifyArray;
        static string thisFile;
        static string newResult;
        static string[] lowerCase = new string[6] { "a", "b", "c", "d", "e", "f", };
        static string[] upperCase = new string[6] { "A", "B", "C", "D", "E", "F", };

        /// <summary>
        /// A string that represents a valid Hex Value.
        /// </summary>
        private static string hex = "0123456789ABCDEFabcdef";

        /// <summary>
        /// A string that represents a valid Hexifyed string.
        /// </summary>
        private static string hex2 = "0123456789ABCDEFabcdefx ";

        /// <summary>
        /// StringComparison to ignore Cases for our modded string extansions.
        /// </summary>
        private static StringComparison ignore = StringComparison.CurrentCultureIgnoreCase;

        public Hexifyer() { InitializeComponent(); }

        private void textOpen_DragEnter(object sender, DragEventArgs e) {
            //Makes sure that the user is dropping a file, not text
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                //Allows them to continue
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textOpen_DragDrop(object sender, DragEventArgs e) {
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files) textOpen.Text = file.ToString();
        }

        private void Hexifyer_DragEnter(object sender, DragEventArgs e) {
            //Makes sure that the user is dropping a file, not text
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                //Allows them to continue
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Hexifyer_DragDrop(object sender, DragEventArgs e) {
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files) textOpen.Text = file.ToString();
        }

        private void StartUpCheck(string pathToConf) {
            Settings sett = new Settings();
            if (sett.LastPath != string.Empty) textOpen.Text = sett.LastPath;
            else textOpen.Text = Directory.GetCurrentDirectory() + @"\toHexify.txt";

            checkaA.Checked = sett.LowerToUpper;
            checkClose.Checked = sett.CloseApp;
            checkDEH.Checked = sett.Dehexify;
            checkNNF.Checked = sett.NoNewFile;

            if (sett.ByteAllign == (int)ByteAllign.b1) radioB1.Checked = true;
            else if (sett.ByteAllign == (int)ByteAllign.b2) radioB2.Checked = true;
            else if (sett.ByteAllign == (int)ByteAllign.b4) radioB4.Checked = true;
            else if (sett.ByteAllign == (int)ByteAllign.b8) radioB8.Checked = true;
            else if (sett.ByteAllign == (int)ByteAllign.b16) radioB16.Checked = true;
            else radioB16.Checked = true;

            if (sett.HexAllign == (int)HexAllign.x4) radioH4.Checked = true;
            else if (sett.HexAllign == (int)HexAllign.x8) radioH8.Checked = true;
            else if (sett.HexAllign == (int)HexAllign.x16) radioH16.Checked = true;
            else radioH16.Checked = true;
        }

        private void Hexifyer_Load(object sender, EventArgs e) {
            buttonHexify.Enabled = false;
            textOpen.DragEnter += new DragEventHandler (textOpen_DragEnter);
            textOpen.DragDrop += new DragEventHandler(textOpen_DragDrop);
            DragEnter += new DragEventHandler(Hexifyer_DragEnter);
            DragDrop += new DragEventHandler(Hexifyer_DragDrop);

            StartUpCheck("hexifyer.conf");
        }

        private string LowerToUpperCase(string line) {
            string buffer = line;
            for (int i = 0; i < 6; i++) {
                newResult = buffer.Replace(lowerCase[i], upperCase[i]);
                buffer = newResult;
            }
            return newResult;
        }

        /// <summary>
        /// Get the User Choosen Byte Allign.
        /// </summary>
        /// <returns>The User Choosen Byte Allign.</returns>
        private ByteAllign GetByteAllign() {
            if (radioB1.Checked) return ByteAllign.b1;
            else if (radioB2.Checked) return ByteAllign.b2;
            else if (radioB4.Checked) return ByteAllign.b4;
            else if (radioB16.Checked) return ByteAllign.b8;
            else return ByteAllign.b16;
        }

        /// <summary>
        /// Get the User Choosen Hex Allign.
        /// </summary>
        /// <returns>The User Choosen Hex Allign.</returns>
        private HexAllign GetHexAllign() {
            if (radioH4.Checked) return HexAllign.x4;
            else if (radioH8.Checked) return HexAllign.x8;
            else return HexAllign.x16;
        }

        /// <summary>
        /// Replace Line Break out of hte source string.
        /// </summary>
        /// <param name="source">The source string to use.</param>
        /// <returns>The Formated string without line breaks.</returns>
        public string ReplaceLineBreak(string source) { return Regex.Replace(source, @"\r\n?|\n", ""); }

        /// <summary>
        /// Check the Byte and Hex Allignment for missmatch. If so it corrects them and returns the result.
        /// </summary>
        /// <param name="_byte">The Byte Allignment as enum.</param>
        /// <param name="_hex">The Hex Allignment as enum.</param>
        /// <returns>The corrected Allignment if missmatch, else it returns the orig values.</returns>
        public int[] CheckByteAndHexAllign(ByteAllign _byte, HexAllign _hex) {
            int[] result = new int[2];
            result[0] = (int)_byte;
            result[1] = (int)_hex;

            if (_hex == HexAllign.x4) {
                if (_byte == ByteAllign.b16 || _byte == ByteAllign.b8) result[0] = (int)ByteAllign.b4;
            } else if (_hex == HexAllign.x8) {
                if (_byte == ByteAllign.b16) result[0] = (int)ByteAllign.b8;
            }
            return result;
        }

        /// <summary>
        /// Checks if a string do contain a specific string including StringCoparison option.
        /// </summary>
        /// <param name="source">The source string to check.</param>
        /// <param name="toCheck">The string that shall be looked for.</param>
        /// <param name="comparison">String Comparison options.</param>
        /// <returns>True if the string to look for was found., else false.</returns>
        public bool Contains(string source, string toCheck, StringComparison comparison) { return source.IndexOf(toCheck, comparison) >= 0; }

        /// <summary>
        /// Check if a input string is a valid Hex Value.
        /// </summary>
        /// <param name="value">The value to check for.</param>
        /// <returns>True if the value contains only Hex values, else False.</returns>
        public static bool IsHex(string value) {
            for (int i = 0; i < value.Length; i++) if (!hex.Contains(value[i].ToString())) return false;     // Loop trough the whole string and check every single digit if it is not a hex value. If so return false.
            return true;
        }

        /// <summary>
        /// Check if a input string array is a valid Hex Value.
        /// </summary>
        /// <param name="value">The value to check for.</param>
        /// <returns>True if the value contains only Hex values, else False.</returns>
        public static bool IsHex(string[] value) {
            foreach (string line in value) {
                for (int i = 0; i < line.Length; i++) if (!hex.Contains(line[i].ToString())) return false;     // Loop trough the whole string and check every single digit if it is not a hex value. If so return false.
            } 
            return true;
        }

        /// <summary>
        /// Check if a string is already Hexifyed.
        /// </summary>
        /// <param name="source">The source string to use.</param>
        /// <returns>True if the string is already hexifyed.</returns>
        public bool IsHexifyed(string source) {
            if (!Contains(source, "0x**", ignore)) return false;
            for (int i = 0; i < source.Length; i++) if (!hex2.Contains(source[i].ToString())) return false;     // Loop trough the whole string and check every single digit if it is not a hex value. If so return false.
            return true;
        }

        /// <summary>
        /// Check if a string array is already Hexifyed.
        /// </summary>
        /// <param name="source">The source string array to use.</param>
        /// <returns>True if the string array is already hexifyed.</returns>
        public bool IsHexifyed(string[] source) {
            if (!source.Contains("0x**")) return false;
            foreach (string line in source) {
                for (int i = 0; i < line.Length; i++) if (!hex2.Contains(line[i].ToString())) return false;     // Loop trough the whole string and check every single digit if it is not a hex value. If so return false.
            }
            return true;
        }

        /// <summary>
        /// Hexify a sring array.
        /// </summary>
        /// <param name="source">The source string array to use.</param>
        /// <param name="_byte">The Byte Allignment.</param>
        /// <param name="_hex">The Hex Allignment.</param>
        /// <returns>The Hexifyed string array.</returns>
        public string[] Hexify(string[] source, ByteAllign _byte, HexAllign _hex) {
            int[] corrected = CheckByteAndHexAllign(_byte, _hex);                              // Check if Byte and Hex are correct alligned.
            _byte = (ByteAllign)corrected[0];
            _hex = (HexAllign)corrected[1];

            List<string> hexifyed = new List<string>();                                        // Initialize a new string List to store our hexifyed strings.
            string toHex = string.Empty;                                                       // The string which shall be hexifyed.
            string x0 = "0x";                                                                  // Represents the '0x' Hex value descriptor.
            string patt = " ";                                                                 // Pattern.
            int toHexCount = 0;                                                                // Count for the string to hexify.
            int subStringCount = (int)_byte * 2;                                               // Set the length of the substring acording to byte length.

            foreach (string line in source) {                                                  // Loop over all lines now.
                if (!string.IsNullOrEmpty(line)) {                                             // If string hase some data.
                    int hexCount, byteCount;                                                   // Byte and hex counters.
                    hexCount = byteCount = 0;                                                  // Init to 0.
                    toHex = ReplaceLineBreak(line.Replace(" ", ""));                           // Get string to hexify and delete white space and line breaks out of it.
                    toHexCount = toHex.Length;                                                 // Set the length of the string to hexify as a counter to decrement.
                    string hex = string.Empty;                                                 // Represents the hexifyed values.

                    for (int i = 0; i < toHex.Length; i += subStringCount) {                   // Loop over all Characters and increment the counter with the length of the substring.
                        if (toHexCount < subStringCount) subStringCount = toHexCount;          // If the length of the string is shorter then the substring we reset the substring length.
                        byteCount += (int)_byte;                                               // Count byte counter up based on the defined byte length.
                        toHexCount -= subStringCount;                                          // Decrement the Counter for the string to hexify with the length of the substring.
                        hexCount++;                                                            // Increment the hex counter.

                        if (toHexCount == 0 || byteCount == 16) {                              // If we have reached the end of the string or already collected 16 bytes.
                            hex += x0 + toHex.Substring(i, subStringCount);                    // Generate the hexifyed string without patting on end.
                            hexifyed.Add(hex);                                                 // Add the new hexifyed string to the string list.
                            if (toHexCount == 0) break;                                        // If we have reached the end  break the loop now to avoid additional pattern on end.
                            if (byteCount == 16) {                                             // IF we haved collected 16 bytes.
                                byteCount = hexCount = 0;                                      // Reset the counters.
                                hex = string.Empty;                                            // Empty the new hex string.
                            }
                        } else hex += x0 + toHex.Substring(i, subStringCount) + patt;          // else Generate the hexifyed string with additional pattern on end.

                        if (hexCount == (int)_hex) {                                           // If hex counter matches defined hex length.
                            hex += patt;                                                       // Add additional pattern.
                            hexCount = 0;                                                      // Clear counter.
                        }
                    }
                }
            }
            return hexifyed.ToArray();
        }

        private string Hexify(string fileToUse) {
            // What's the file size?
            FileInfo fileInfo = new FileInfo(fileToUse);
            long n = fileInfo.Length;

            // Do we use a empty File?
            if (n == 0) return result;

            // Read up the Input File into a String Array
            toHexifyArray = File.ReadAllLines(fileToUse);

            // If source array is not hex, break here.
            if (!IsHex(toHexifyArray)) {
                MessageBox.Show("Input File is not in Hex !");
                return "";
            }

            // Shall we use the same file?
            if (checkNNF.Checked == true) {
                // Delete the Input file and new create it
                File.Delete(fileToUse);
                File.Create(fileToUse).Close();
                thisFile = fileToUse;
            } else {
                // Create the new empty file to fil up
                File.Create(textOpen.Text + "_hexifyed.txt").Close();
                thisFile = textOpen.Text + "_hexifyed.txt";
            }

            int[] _result = new int[2];
            _result = CheckByteAndHexAllign(GetByteAllign(), GetHexAllign());

            toHexifyArray = Hexify(toHexifyArray, (ByteAllign)_result[0], (HexAllign)_result[1]);
            File.WriteAllLines(thisFile, toHexifyArray);

            result = "Done!";
            return result;
        }

        /// <summary>
        /// Dehexify a string.
        /// </summary>
        /// <param name="source">The source string array to use.</param>
        /// <returns>The Dehexifyed strings as Array.</returns>
        public string[] Dehexify(string[] source) {
            List<string> deHexifyed = new List<string>();
            foreach (string line in source) {
                if (!string.IsNullOrEmpty(line)) deHexifyed.Add(line.Replace("0x", "").Replace(" ", ""));
            }
            return deHexifyed.ToArray();
        }

        private string DeHexify(string fileToUse) {
            // What's the file size?
            FileInfo fileInfo = new FileInfo(fileToUse);
            long n = fileInfo.Length;

            // Do we use a empty File?
            if (n == 0) return result;

            // Read up the Input File into a String Array
            toHexifyArray = File.ReadAllLines(fileToUse);

            // Check if input file is realy already Hexifyed.
            if (!IsHexifyed(toHexifyArray)) {
                MessageBox.Show("Input file is not only Hexifyed Data !");
                return "";
            }

            // Shall we use the same file?
            if (checkNNF.Checked == true) {
                // Delete the Input file and new create it
                File.Delete(fileToUse);
                File.Create(fileToUse).Close();
                thisFile = fileToUse;
            }
            else {
                // Create the new empty file to fil up
                File.Create(textOpen.Text + "_hexifyed.txt").Close();
                thisFile = textOpen.Text + "_hexifyed.txt";
            }

            toHexifyArray = Dehexify(toHexifyArray);
            File.WriteAllLines(thisFile, toHexifyArray);

            result = "Done!";
            return result;
        }

        private void textOpen_TextChanged(object sender, EventArgs e) {
            if (textOpen.Text != "Open File to Hexify...") buttonHexify.Enabled = true;

            string str1 = textOpen.Text;
            string str2 = "hexifyer.conf";
            bool contains;

            if ((contains = str1.Contains(str2))) StartUpCheck(textOpen.Text);
        }

        private void buttonOpen_Click(object sender, EventArgs e) {
            if (openFile.ShowDialog() == DialogResult.OK) {
                textOpen.Text = openFile.FileName;
                buttonHexify.Enabled = true;
            }
        }

        private void buttonHexify_Click(object sender, EventArgs e) {
            if (textOpen.Text != "Open File to Hexify...") {
                string retur;
                string method;
                if (checkDEH.Checked != true) {
                    retur = Hexify(textOpen.Text);
                    method = "Hexifyed!";
                }
                else {
                    retur = DeHexify(textOpen.Text);
                    method = "DeHexifyed!";
                }

                if (retur == "Done!") {
                    MessageBox.Show("Done!\nYour File would be successful " + method);
                    if (checkClose.Checked == true) Application.Exit();
                }
                else if (retur == "ERROR!") MessageBox.Show("Nice Try ^^\nNext time don't feed me with a empty file....\nif you want to see any result :P");
            }
        }

        private void Hexifyer_FormClosing(object sender, FormClosingEventArgs e) {
            Settings sett = new Settings();
            if (textOpen.Text != string.Empty) sett.LastPath = textOpen.Text;

            sett.LowerToUpper = checkaA.Checked;
            sett.CloseApp = checkClose.Checked;
            sett.Dehexify = checkDEH.Checked;
            sett.NoNewFile = checkNNF.Checked;

            if (radioB1.Checked) sett.ByteAllign = (int)ByteAllign.b1;
            else if (radioB2.Checked) sett.ByteAllign = (int)ByteAllign.b2;
            else if (radioB4.Checked) sett.ByteAllign = (int)ByteAllign.b4;
            else if (radioB8.Checked) sett.ByteAllign = (int)ByteAllign.b8;
            else if (radioB16.Checked) sett.ByteAllign = (int)ByteAllign.b16;
            else sett.ByteAllign = (int)ByteAllign.b16;

            if (radioH4.Checked) sett.HexAllign = (int)HexAllign.x4;
            else if (radioH8.Checked) sett.HexAllign = (int)HexAllign.x8;
            else if (radioH16.Checked) sett.HexAllign = (int)HexAllign.x16;
            else sett.HexAllign = (int)HexAllign.x16;

            sett.Save();
        }
    }
}

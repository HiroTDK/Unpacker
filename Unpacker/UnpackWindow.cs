using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Unpacker
{
	public partial class UnpackWindow : Form
	{
		public UnpackWindow()
		{
			InitializeComponent();

			this.DoubleBuffered = true;

			backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
			backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
			backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
			backgroundWorker.WorkerReportsProgress = true;
			backgroundWorker.WorkerSupportsCancellation = true;

			progressBar1.Maximum = progressBar1.Width;
			progressBar2.Maximum = progressBar2.Width;
		}

		/*----------------------------------------------*\
						Checkboxes				
		\*----------------------------------------------*/

		private void checkLabel_Click( object sender, EventArgs e )
		{
			Label l = (Label)sender;
			switch ( l.Name )
			{
				case "checkLabel1":
					checkBox1.Focus();
					checkBox1.Checked = !checkBox1.Checked;
					break;
				case "checkLabel2":
					checkBox2.Focus();
					checkBox2.Checked = !checkBox2.Checked;
					break;
				case "checkLabel3":
					checkBox3.Focus();
					checkBox3.Checked = !checkBox3.Checked;
					break;
				case "checkLabel4":
					checkBox4.Focus();
					checkBox4.Checked = !checkBox4.Checked;
					break;
			}
		}

		private void checkBox_GotFocus( object sender, EventArgs e )
		{
			CheckBox c = (CheckBox)sender;
			switch ( c.Name )
			{
				case "checkBox1":
					checkLabel1.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox2":
					checkLabel2.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox3":
					checkLabel3.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox4":
					checkLabel4.BackColor = Color.FromArgb(95, 95, 95);
					break;
			}
		}

		private void checkBox_LostFocus( object sender, EventArgs e )
		{
			CheckBox c = (CheckBox)sender;
			switch ( c.Name )
			{
				case "checkBox1":
					checkLabel1.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox2":
					checkLabel2.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox3":
					checkLabel3.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox4":
					checkLabel4.BackColor = Color.FromArgb(63, 63, 63);
					break;
			}
		}

		private void checkBox_CheckedChanged( object sender, EventArgs e )
		{
			CheckBox c = (CheckBox)sender;
			if ( c.Checked )
			{
				c.FlatAppearance.MouseOverBackColor = Color.White;
			}
			else
			{
				c.FlatAppearance.MouseOverBackColor = Color.FromArgb(127, 127, 127);
			}
		}



		/*----------------------------------------------*\
					ROM And Path Selection
		\*----------------------------------------------*/

		private string file;
		private string path;
		private string folder;

		//---- Button action for selection of file. ----\\

		private void button1_Click( object sender, EventArgs e )
		{
			//----- Creating the open file dialog box. -----\\
			
			using ( OpenFileDialog openFileDialog = new OpenFileDialog() )
			{
				openFileDialog.Title = "Select a ROM to unpack.";
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				openFileDialog.RestoreDirectory = true;
				openFileDialog.Filter = "NDS ROM (*.nds)|*.nds";
				DialogResult result = openFileDialog.ShowDialog();

				//---- Testing the open file dialog result. ----\\

				if ( result != DialogResult.OK )
				{
					// Presumption of cancellation.
					return;
				}

				byte[] rom;

				if ( openFileDialog.CheckFileExists )
				{
					// Tests the select file and reads them to an array.
					rom = File.ReadAllBytes(openFileDialog.FileName);
				}
				else
				{
					// Presumes an error in choice of file.
					return;
				}

				//---- Testing the selected ROM for errors. ----\\

				if ( rom.Length < 136 )
				{
					result = CustomMessageBox.Show(
						"This file isn't long enough to define a header."
							+ " Header size is 4 bytes long and stored at byte 132 (0x84). This file is only "
							+ rom.Length + " (0x" + rom.Length.ToString("X") + ") bytes long.",
						"File Length Error",
						400,
						new List<string>(),
						new List<DialogResult>());

					return;
				}

				using ( MemoryStream memoryStream = new MemoryStream(rom) )
				{
					rom = new byte[4];
					memoryStream.Position = 132;
					memoryStream.Read(rom, 0, 4);
					int headerSize = BitConverter.ToInt32(rom, 0);

					if ( headerSize != 16384 )
					{
						result = CustomMessageBox.Show(
							"The 4 bytes at 132 (0x84) indicate that the header size is "
							+ headerSize + " (0x" + headerSize.ToString("X") + ") bytes long."
							+ " All known headers are 16384 (0x4000) bytes long,"
							+ " The header size is either incorrect or the ROM is corrupted."
							+ " Would you like to proceed anyway?",
							"Header Size Error",
							400,
							new List<string>() { "Yes", "No" },
							new List<DialogResult>() { DialogResult.Yes, DialogResult.No });

						if ( result != DialogResult.Yes )
						{
							return;
						}
					}

					if ( memoryStream.Length < headerSize )
					{
						result = CustomMessageBox.Show(
							"The header size defined at 132 (0x84) indicates a header size of "
							+ headerSize + "(0x" + headerSize.ToString("X") + ") bytes."
							+ "This file is only " + memoryStream.Length + " (0x" + memoryStream.Length.ToString("X") + ") bytes long.",
							"Header Size Error",
							400,
							new List<string>() { },
							new List<DialogResult>() { });

						return;
					}

					//----- Creates a preliminary folder name. -----\\

					rom = new byte[16];
					memoryStream.Position = 0;
					memoryStream.Read(rom, 0, 16);

					folder = "[" + System.Text.Encoding.UTF8.GetString(rom, 12, 4);
					folder += "] " + System.Text.Encoding.UTF8.GetString(rom, 0, 10);
				}

				this.file = openFileDialog.FileName;
				this.label2.Text = openFileDialog.SafeFileName;

				this.button2.Enabled = true;
				this.label4.Text = "Select a destination.";
				this.label4.Enabled = true;
			}
		}

		//---- Button action for selection of path. ----\\

		private void button2_Click( object sender, EventArgs e )
		{
			// For the off-chance of no file selection or file of no size.
			if ( file == null || file.Length == 0 )
			{
				DialogResult result = CustomMessageBox.Show(
					"Something can't come from nothing. This, unfortunately, is nothing. That's actually incorrect."
					+ " \"This is nothing\" doesn't make sense. You can't have nothing isn't."
					+ " If nothing wasn't, there'd be all kinds of stuff, like giant ants with top hats dancing around."
					+ " There's no room for all that.",
					"No File Chosen",
					400,
					new List<string>(),
					new List<DialogResult>());

				return;
			}

			//--- Creating the folder select dialog box. ---\\

			using ( FolderBrowserDialog browser = new FolderBrowserDialog() )
			{
				while ( true )
				{
					browser.Description = "Select a location to unpack the ROM."
						+ " The unpacker will create a new folder, titled \""
						+ folder + "\", in the selected location."
						+ " All files will be unpacked into this new folder.";
					browser.RootFolder = Environment.SpecialFolder.Desktop;
					DialogResult result = browser.ShowDialog();

					if ( result != DialogResult.OK )
					{
						// Presumption of cancellation.
						return;
					}

					//-- Builds the final extraction folder name. --\\

					path = browser.SelectedPath;

					if ( !Path.GetFileName(path).StartsWith(folder) )
					{
						path += "\\" + folder;
					}

					// If the folder exists ...
					if ( Directory.Exists(path) )
					{
						// ... run through existing folders for an appropriate suffix.
						int i = 2;
						while ( true )
						{
							if ( Directory.Exists(path + " (" + i + ")") )
							{
								i++;
							}
							else
							{
								break;
							}
						}
						result = CustomMessageBox.Show(
							"The selected folder contains a folder with the same name as the new directory."
							+ " Would you like to create a second directory here, appending \" (" + i + ")\" to the directory name,"
							+ " or would you prefer to overwrite the existing folder with a new directory?",
							"Directory Already Exists",
							400,
							new List<string>() { "New Directory", "Overwrite" },
							new List<DialogResult>() { DialogResult.Ignore, DialogResult.Retry });

						if ( result == DialogResult.Ignore )
						{
							// Append suffix to folder name.
							path += " (" + i + ")";
							break;
						}
						else if ( result == DialogResult.Retry )
						{
							DialogResult delete = CustomMessageBox.Show(
								"Are you sure you would like to delete ths folder and its contents?"
								+ "\n\n" + path + "\n\n"
								+ "These folder and its files cannot (easily) be recovered.",
								"Delete Folder?",
								450,
								new List<string>() { "Yes", "No" },
								new List<DialogResult>() { DialogResult.Yes, DialogResult.No });

							if ( delete == DialogResult.Yes )
							{
								try
								{
									Directory.Delete(path, true);
								}
								catch ( Exception exception )
								{
									DialogResult dialog = CustomMessageBox.Show(
										exception.Message,
										exception.GetType().ToString(),
										400,
										new List<string>(),
										new List<DialogResult>());
								}
								break;
							}
							else
							{
								continue;
							}
						}
						else
						{
							continue;
						}
					}
					else
					{
						break;
					}
				}

				label4.Text = path;
				button3.Enabled = true;
			}
		}


		/*----------------------------------------------*\
					    ROM Unpacking
		\*----------------------------------------------*/

		private void button4_Click( object sender, EventArgs e )
		{
			if ( backgroundWorker.IsBusy )
			{
				backgroundWorker.CancelAsync();
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			if ( backgroundWorker.IsBusy )
			{
				return;
			}

			if ( file == null || file.Length == 0 )
			{
				DialogResult result = CustomMessageBox.Show(
					"Something can't come from nothing. This, unfortunately, is nothing. That's actually incorrect."
					+ " \"This is nothing\" doesn't make sense. You can't have nothing isn't."
					+ " If nothing wasn't, there'd be all kinds of stuff, like giant ants with top hats dancing around."
					+ " There's no room for all that.",
					"No File Chosen",
					400,
					new List<string>(),
					new List<DialogResult>());

				return;
			}

			if ( path == null || path.Length == 0 )
			{
				DialogResult result = CustomMessageBox.Show(
					"You haven't chosen a directory to store the unpacked file tree."
					+ "Where do you think you're going to put a tree that big?",
					"No Directory Chosen",
					400,
					new List<string>(),
					new List<DialogResult>());

				return;
			}

			button1.Enabled = false;
			button2.Enabled = false;
			button3.Enabled = false;
			button4.Enabled = true;
			label2.Enabled = false;
			label4.Enabled = false;
			checkBox1.Enabled = false;
			checkBox2.Enabled = false;
			checkBox3.Enabled = false;
			checkBox4.Enabled = false;
			checkLabel1.Enabled = false;
			checkLabel2.Enabled = false;
			checkLabel3.Enabled = false;
			checkLabel4.Enabled = false;

			backgroundWorker.RunWorkerAsync();
		}

		private void backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
		{
			BackgroundWorker worker = (BackgroundWorker)sender;
			worker.ReportProgress(0, new Tuple<int, string, int, int>(0, "Reading System Files", 0, 0));

			if ( !File.Exists(file) )
			{
				DialogResult result = CustomMessageBox.Show(
						"The file that you've specified doesn't exist or has changed locations."
						+ " Please check the path and file name for any errors and try again.",
						"File Doesn't Exist",
						400,
						new List<string>(),
						new List<DialogResult>());

				return;
			};

			if ( worker.CancellationPending )
			{
				e.Cancel = true;
				return;
			}

			if ( !Directory.Exists(path) )
			{
				try
				{
					Directory.CreateDirectory(path);
				}
				catch ( Exception exception )
				{
					DialogResult dialog = CustomMessageBox.Show(
						exception.Message,
						exception.GetType().ToString(),
						400,
						new List<string>(),
						new List<DialogResult>());

					return;
				}
			}

			if ( worker.CancellationPending )
			{
				e.Cancel = true;
				return;
			}

			using ( MemoryStream romStream = new MemoryStream(File.ReadAllBytes(file)) )
			{
				using ( BinaryReader romReader = new BinaryReader(romStream) )
				{
					romReader.BaseStream.Position = 32;
					int arm9Offset = Convert.ToInt32(romReader.ReadUInt32());
					romReader.BaseStream.Position = 44;
					int arm9Length = Convert.ToInt32(romReader.ReadUInt32());
					int arm7Offset = Convert.ToInt32(romReader.ReadUInt32());
					romReader.BaseStream.Position = 60;
					int arm7Length = Convert.ToInt32(romReader.ReadUInt32());
					int fntOffset = Convert.ToInt32(romReader.ReadUInt32());
					int fntLength = Convert.ToInt32(romReader.ReadUInt32());
					int fatOffset = Convert.ToInt32(romReader.ReadUInt32());
					int fatLength = Convert.ToInt32(romReader.ReadUInt32());
					int oat9Offset = Convert.ToInt32(romReader.ReadUInt32());
					int oat9Length = Convert.ToInt32(romReader.ReadUInt32());
					int oat7Offset = Convert.ToInt32(romReader.ReadUInt32());
					int oat7Length = Convert.ToInt32(romReader.ReadUInt32());
					romReader.BaseStream.Position = 104;
					int bnrOffset = Convert.ToInt32(romReader.ReadUInt32());
					romReader.BaseStream.Position = bnrOffset;
					int bnrLength = Convert.ToInt32(romReader.ReadUInt16());
					switch (bnrLength)
					{
						case 1:
							bnrLength = 2112;
							break;
						case 2:
							bnrLength = 2112;
							break;
						case 3:
							bnrLength = 3072;
							break;
						case 259:
							bnrLength = 9216;
							break;
					}

					byte[] fntArray = new byte[fntLength];
					byte[] fatArray = new byte[fatLength];

					romReader.BaseStream.Position = fntOffset;
					romReader.Read(fntArray, 0, fntLength);
					romReader.BaseStream.Position = fatOffset;
					romReader.Read(fatArray, 0, fatLength);

					if ( fatArray.Count() % 8 > 0 )
					{
						// Exception handling for rewrite later.
						throw new Exception(
							"Table length must be a multiple of 8. This table has a length of " + fatArray.Count() + "."
							+ "\n " + fatArray.Count() + " ÷ 8 = " + ( fatArray.Count() / 8 )
							+ "\n Remainder: " + ( fatArray.Count() % 8 )
							);
					}
					
					List<FileNDS> fileList = new List<FileNDS>();
					fileList.Add(new FileNDS("Header", "", "", 0, 16384));
					fileList.Add(new FileNDS("File Name Table", "", "", fntOffset, fntLength));
					fileList.Add(new FileNDS("File Allocation Table", "", "", fatOffset, fatLength));
					fileList.Add(new FileNDS("Banner", "", ".bnr", bnrOffset, bnrLength));
					fileList.Add(new FileNDS("ARM9 Binary", "", ".bin", arm9Offset, arm9Length));
					fileList.Add(new FileNDS("ARM9 Overlay Table", "", "", oat9Offset, oat9Length));
					if ( arm7Length > 0 )
					{
						fileList.Add(new FileNDS("ARM7 Binary", "", ".bin", arm7Offset, arm9Length));
					}
					if ( oat7Length > 0 )
					{
						fileList.Add(new FileNDS("ARM7 Overlay Table", "", "", oat7Offset, oat9Length));
					}

					int directoryCount = BitConverter.ToUInt16(fntArray, 6);
					int firstFile = BitConverter.ToInt16(fntArray, 4);
					int fileCount = fatArray.Count() / 8;
					int workload = (fileCount * 4) + (directoryCount * 2);
					int progress = 0;
					
					worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Reading File Name And Allocation Tables", fileCount, 0));
					FileNDS[] files = new FileNDS[fileCount];

					for ( int i = 0; i < fileCount; i++ )
					{
						if ( worker.CancellationPending )
						{
							e.Cancel = true;
							return;
						}

						files[i] = new FileNDS();
						FileNDS currentFile = files[i];
						files[i].Offset = Convert.ToInt32(BitConverter.ToUInt32(fatArray, i * 8));
						files[i].Length = Convert.ToInt32(BitConverter.ToUInt32(fatArray, i * 8 + 4)) - files[i].Offset;

						progress++;
						worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Reading File Allocation Table", fileCount, i + 1));
					}

					worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Reading Overlay Allocation Table", firstFile, 0));

					string[] directories;
					List<string> dirList = new List<string>();
					directories = new string[directoryCount];
					if ( firstFile > 0 )
					{
						directories[0] = "\\Root";
						dirList.Add("\\Overlays");
						for ( int i = 0; i < firstFile; i++ )
						{
							if ( worker.CancellationPending )
							{
								e.Cancel = true;
								return;
							}

							files[i].Name = "Overlay " + i.ToString("D" + firstFile.ToString().Length) + ".bin";
							files[i].Path = "\\Overlays";

							progress++;
							worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Reading Overlay Allocation Table", firstFile, i + 1));
						}
					}
					else
					{
						directories[0] = "";
					}

					worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Reading File Name Table", fileCount + directoryCount, 0));

					int unnamedCount = 0;
					int dirProgress = 0;
					int fileProgress = 0;

					for ( int i = 0; i < directoryCount; i++ )
					{
						int entryPos = Convert.ToInt32(BitConverter.ToUInt32(fntArray, i * 8));
						int fileIndex = Convert.ToInt32(BitConverter.ToUInt16(fntArray, ( i * 8 ) + 4));

						while ( true )
						{
							if ( worker.CancellationPending )
							{
								e.Cancel = true;
								return;
							}

							byte entryByte = fntArray[entryPos++];

							if ( entryByte == 0 )
							{
								break;
							}

							else if ( entryByte == 128 )
							{
								int index = BitConverter.ToUInt16(fntArray, entryPos) - 61440;
								directories[index] = directories[i] + "\\Unnamed " + unnamedCount++;
								dirProgress++;
								entryPos += 2;
							}

							else if ( entryByte > 128 )
							{
								int index = BitConverter.ToUInt16(fntArray, ( entryPos ) + ( entryByte - 128 )) - 61440;
								directories[index] = directories[i] + "\\" + System.Text.Encoding.UTF8.GetString(fntArray, entryPos, entryByte - 128);
								dirProgress++;
								entryPos += ( entryByte - 128 ) + 2;
							}

							else
							{
								files[fileIndex].Name = System.Text.Encoding.UTF8.GetString(fntArray, entryPos, entryByte);
								files[fileIndex].Path = directories[i];
								fileIndex++;
								fileProgress++;
								entryPos += entryByte;
							}

							progress++;
							worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Reading File Name Table", fileCount + directoryCount, dirProgress + fileProgress));
						}
					}

					worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Getting File Extensions", fileCount, 0));

					fileList.AddRange(files.ToList());
					dirList.AddRange(directories.ToList());
					files = null;
					directories = null;
					List<FileNDS> narcList = new List<FileNDS>();
					for ( int i = 0; i < fileCount; i++ )
					{
						if ( worker.CancellationPending )
						{
							e.Cancel = true;
							return;
						}

						FileNDS file = fileList[i];
						file.GetExtension(romStream);
						
						if ( checkBox1.Checked && file.Extension == ".narc" )
						{
							narcList.Add(file);
							workload++;
						}

						progress++;
						worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Getting File Extensions", fileCount, i + 1));
					}
					
					worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Reading NARC Files", directoryCount, 0));

					if ( checkBox1.Checked && narcList.Count > 0 )
					{
						for ( int i = 0; i < narcList.Count; i++ )
						{
							if ( worker.CancellationPending )
							{
								e.Cancel = true;
								return;
							}

							FileNDS file = narcList[i];
							NARC narc = new NARC(romStream, file);
							if ( narc.isValid )
							{
								fileList.Remove(file);
								dirList.AddRange(narc.dirList);
								fileList.AddRange(narc.fileList);
							}

							progress++;
							worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Reading NARC Files", narcList.Count, i + 1));
						}
					}

					worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Writing Folder Structure", directoryCount, 0));

					double compWorkload = directoryCount / dirList.Count;
					for ( int i = 0; i < dirList.Count; i++ )
					{
						if ( worker.CancellationPending )
						{
							e.Cancel = true;
							return;
						}

						Directory.CreateDirectory(path + dirList[i]);

						int p = Convert.ToInt32(( i + 1 ) * compWorkload);
						worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress + p, "Writing Folder Structure", directoryCount, (int)((i + 1) * compWorkload)));
					}

					progress += directoryCount;
					worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Extracting Files", fileList.Count, 0));

					compWorkload = (double)fileCount / (double)fileList.Count;
					for ( int i = 0; i < fileList.Count; i++ )
					{
						if ( worker.CancellationPending )
						{
							e.Cancel = true;
							return;
						}

						FileNDS file = fileList[i];
						romReader.BaseStream.Position = file.Offset;
						byte[] image = new byte[file.Length];
						romReader.Read(image, 0, file.Length);

						using ( BinaryWriter writer = new BinaryWriter(File.Open(path + file.Path + "\\" + file.Name + file.Extension, FileMode.Create)) )
						{
							writer.Write(image, 0, file.Length);
						}

						int p = Convert.ToInt32(( i + 1 ) * compWorkload);
						worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress + p, "Extracting Files", fileList.Count, (i + 1)));
					}
				}
			}
		}

		public void backgroundWorker_ProgressChanged( object sender, ProgressChangedEventArgs e )
		{
			Tuple<int, string, int, int> report = e.UserState as Tuple<int, string, int, int>;

			progressBar1.Text = report.Item2;
			if ( e.ProgressPercentage > 0)
			{
				int value = Convert.ToInt32(( (double)progressBar1.Maximum / (double)e.ProgressPercentage ) * report.Item1);
				if ( progressBar1.Value != value )
				{
					progressBar1.Value = value;
				}
			}

			if ( report.Item3 > 0 )
			{
				int value = Convert.ToInt32(( (double)progressBar2.Maximum / (double)report.Item3 ) * report.Item4);
				if ( progressBar2.Value != value )
				{
					progressBar2.Text = report.Item4 + " / " + report.Item3;
					progressBar2.Value = value;
				}
			}
		}

		public void backgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			if (e.Cancelled)
			{
				{
					DialogResult result = CustomMessageBox.Show(
							"The unpacking operation has been cancelled."
							+ " Would you like to delete the currently extracted files?",
							"Unpacking Cancelled",
							400,
							new List<string>() { "Keep", "Delete" },
							new List<DialogResult>() { DialogResult.Cancel, DialogResult.Yes });

					if ( result == DialogResult.Yes )
					{
						try
						{
							Directory.Delete(path, true);
							button3.Enabled = true;
							progressBar1.Value = 0;
							progressBar1.Text = "Unpacking Cancelled; Files Deleted";
							progressBar2.Value = 0;

						}
						catch ( Exception exception )
						{
							DialogResult dialog = CustomMessageBox.Show(
								"There was an error deleting the extracted files."
								+ " The folder may have been deleted, moved, locked, or renamed by another process."
								+ " If the folder persists, the files will be left there."
								+ " If you wish to delete them, you must do so manually.",
								exception.GetType().ToString(),
								400,
								new List<string>(),
								new List<DialogResult>());

							path = "";
							label4.Text = "";
							progressBar1.Text = "Unpacking Cancelled; Files Not Deleted";
							progressBar2.Text = ( ( progressBar1.Value * 100 ) / ( progressBar1.Maximum * 100 ) ) + "%";
							progressBar2.Value = 0;
						}
					}
					else
					{
						path = "";
						label4.Text = "";
						progressBar1.Text = "Unpacking Cancelled; Files Not Deleted";
						progressBar2.Text = ( ( progressBar1.Value * 100 ) / ( progressBar1.Maximum * 100 ) ) + "%";
						progressBar2.Value = 0;
					}
				}
			}
			else
			{
				path = "";
				label4.Text = "";
				progressBar1.Text = "Unpacking Completed";
				progressBar2.Text = "100%";
			}

			label2.Enabled = true;
			label4.Enabled = true;
			checkBox1.Enabled = true;
			checkLabel1.Enabled = true;
			button1.Enabled = true;
			button2.Enabled = true;
			button4.Enabled = false;

			progressBar1.Refresh();
			progressBar2.Refresh();
		}
	}
}

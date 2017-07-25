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

			romWorker.DoWork += new DoWorkEventHandler(romWorker_DoWork);
			romWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
			romWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
			romWorker.WorkerReportsProgress = true;
			romWorker.WorkerSupportsCancellation = true;
			
			narcWorker.DoWork += new DoWorkEventHandler(narcWorker_DoWork);
			narcWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
			narcWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
			narcWorker.WorkerReportsProgress = true;
			narcWorker.WorkerSupportsCancellation = true;

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
				case "narcCheckBoxLabel":
					narcCheckBox.Focus();
					narcCheckBox.Checked = !narcCheckBox.Checked;
					break;
				case "sdatCheckBoxLabel":
					sdatCheckBox.Focus();
					sdatCheckBox.Checked = !sdatCheckBox.Checked;
					break;
				case "checkpathTitleLabel":
					checkBox3.Focus();
					checkBox3.Checked = !checkBox3.Checked;
					break;
				case "checkpathButtonLabel":
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
				case "narcCheckBox":
					narcCheckBoxLabel.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "sdatCheckBox":
					sdatCheckBoxLabel.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox3":
					checkpathTitleLabel.BackColor = Color.FromArgb(95, 95, 95);
					break;
				case "checkBox4":
					checkpathButtonLabel.BackColor = Color.FromArgb(95, 95, 95);
					break;
			}
		}

		private void checkBox_LostFocus( object sender, EventArgs e )
		{
			CheckBox c = (CheckBox)sender;
			switch ( c.Name )
			{
				case "narcCheckBox":
					narcCheckBoxLabel.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "sdatCheckBox":
					sdatCheckBoxLabel.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox3":
					checkpathTitleLabel.BackColor = Color.FromArgb(63, 63, 63);
					break;
				case "checkBox4":
					checkpathButtonLabel.BackColor = Color.FromArgb(63, 63, 63);
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
		private bool isArchive = false;
		private bool isNARC = true;

		private void fileButton_Click( object sender, EventArgs e )
		{			
			using ( OpenFileDialog openFileDialog = new OpenFileDialog() )
			{
				openFileDialog.Title = "Select a file to unpack.";
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				openFileDialog.RestoreDirectory = true;
				openFileDialog.Filter = "Supported File Types (*.nds;*.narc)|*.nds;*.narc|Nintendo DS ROM (*.nds)|*.nds|Nitro Archive (.narc)|*.narc";
				DialogResult result = openFileDialog.ShowDialog();
				
				if ( result != DialogResult.OK )
				{
					return;
				}

				byte[] fileArray;

				if ( openFileDialog.CheckFileExists )
				{
					fileArray = File.ReadAllBytes(openFileDialog.FileName);

					string extension = Path.GetExtension(openFileDialog.FileName);
					switch ( extension.ToLower() )
					{
						case ".nds":
							isArchive = false;
							break;
						case ".narc":
							isArchive = true;
							isNARC = true;
							break;
						case ".sdat":
							isArchive = true;
							isNARC = false;
							break;
					}
				}
				else
				{
					return;
				}

				if (!isArchive)
				{
					if ( fileArray.Length < 136 )
					{
						result = CustomMessageBox.Show(
							"This file isn't long enough to define a header."
								+ " Header size is 4 bytes long and stored at byte 132 (0x84). This file is only "
								+ fileArray.Length + " (0x" + fileArray.Length.ToString("X") + ") bytes long.",
							"File Length Error",
							400,
							new List<string>(),
							new List<DialogResult>());

						return;
					}

					using ( MemoryStream memoryStream = new MemoryStream(fileArray) )
					{
						fileArray = new byte[4];
						memoryStream.Position = 132;
						memoryStream.Read(fileArray, 0, 4);
						int headerSize = BitConverter.ToInt32(fileArray, 0);

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

						fileArray = new byte[16];
						memoryStream.Position = 0;
						memoryStream.Read(fileArray, 0, 16);

						folder = "[" + System.Text.Encoding.UTF8.GetString(fileArray, 12, 4);
						folder += "] " + System.Text.Encoding.UTF8.GetString(fileArray, 0, 10);
					}
				}
				else
				{
					folder = "[" + openFileDialog.SafeFileName + "]";
				}

				this.file = openFileDialog.FileName;
				this.fileButtonLabel.Text = openFileDialog.SafeFileName;

				this.pathButton.Enabled = true;
				this.pathButtonLabel.Text = "Select a destination.";
				this.pathButtonLabel.Enabled = true;
			}
		}

		//---- Button action for selection of path. ----\\

		private void pathButton_Click( object sender, EventArgs e )
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
					browser.Description = "Select a location to unpack the file."
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

					if ( !Path.GetFileName(path).StartsWith(folder))
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

				pathButtonLabel.Text = path;
				unpackButton.Enabled = true;
			}
		}


		/*----------------------------------------------*\
					    ROM Unpacking
		\*----------------------------------------------*/

		private void cancelButton_Click( object sender, EventArgs e )
		{
			if ( romWorker.IsBusy )
			{
				romWorker.CancelAsync();
			}

			if ( narcWorker.IsBusy )
			{
				narcWorker.CancelAsync();
			}
		}

		private void unpackButton_Click( object sender, EventArgs e )
		{
			if ( romWorker.IsBusy )
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

			fileButton.Enabled = false;
			pathButton.Enabled = false;
			unpackButton.Enabled = false;
			cancelButton.Enabled = true;
			fileButtonLabel.Enabled = false;
			pathButtonLabel.Enabled = false;
			narcCheckBox.Enabled = false;
			sdatCheckBox.Enabled = false;
			checkBox3.Enabled = false;
			checkBox4.Enabled = false;
			narcCheckBoxLabel.Enabled = false;
			sdatCheckBoxLabel.Enabled = false;
			checkpathTitleLabel.Enabled = false;
			checkpathButtonLabel.Enabled = false;

			if ( !isArchive )
			{
				romWorker.RunWorkerAsync();
			}
			else if ( isNARC )
			{
				narcWorker.RunWorkerAsync();
			}
			/*
			else
			{
				sdatWorker.RunWorkerAsync();
			}
			*/
		}

		private void romWorker_DoWork( object sender, DoWorkEventArgs e )
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
						
						if ( narcCheckBox.Checked && file.Extension == ".narc" )
						{
							narcList.Add(file);
							workload++;
						}

						progress++;
						worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Getting File Extensions", fileCount, i + 1));
					}
					
					worker.ReportProgress(workload, new Tuple<int, string, int, int>(progress, "Reading NARC Files", directoryCount, 0));

					if ( narcCheckBox.Checked && narcList.Count > 0 )
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
							unpackButton.Enabled = true;
							progressBar1.Value = 0;
							progressBar1.Text = "Unpacking Cancelled; Files Deleted";
							progressBar2.Value = 0;
							progressBar2.Text = "";

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
							pathButtonLabel.Text = "Select a destination folder.";
							pathButtonLabel.Enabled = true;
							pathButton.Enabled = true;
							progressBar1.Text = "Unpacking Cancelled; Files Not Deleted";
							progressBar2.Value = 0;
							progressBar2.Text = "";
						}
					}
					else
					{
						path = "";
						pathButtonLabel.Text = "Select a destination folder.";
						pathButtonLabel.Enabled = true;
						pathButton.Enabled = true;
						progressBar1.Text = "Unpacking Cancelled; Files Not Deleted";
						progressBar2.Text = ( ( progressBar1.Value * 100 ) / ( progressBar1.Maximum * 100 ) ) + "%";
						progressBar2.Value = 0;
					}
				}
			}
			else
			{
				file = "";
				path = "";
				fileButtonLabel.Text = "Select a ROM or archive to unpack.";
				pathButtonLabel.Text = "";
				progressBar1.Text = "Unpacking Completed";
				progressBar2.Text = "100%";
			}

			fileButtonLabel.Enabled = true;
			narcCheckBox.Enabled = true;
			narcCheckBoxLabel.Enabled = true;
			fileButton.Enabled = true;
			cancelButton.Enabled = false;

			progressBar1.Refresh();
			progressBar2.Refresh();
		}

		private void narcWorker_DoWork( object sender, DoWorkEventArgs e )
		{
			BackgroundWorker worker = (BackgroundWorker)sender;
			worker.ReportProgress(0, new Tuple<int, string, int, int>(0, "Reading Archive Header", 0, 0));

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

			using ( MemoryStream narcStream = new MemoryStream(File.ReadAllBytes(file)) )
			{
				using ( BinaryReader narcReader = new BinaryReader(narcStream) )
				{
					FileNDS archive = new FileNDS("", path, "", 0, Convert.ToInt32(narcStream.Length));
					NARC narc = new NARC(narcStream, archive);

					if ( narc.isValid )
					{
						int workload = narc.dirList.Count + narc.fileList.Count;
						worker.ReportProgress(workload, new Tuple<int, string, int, int>(0, "Writing Folder Structure", narc.dirList.Count, 0));

						for ( int i = 1; i < narc.dirList.Count; i++ )
						{
							if ( worker.CancellationPending )
							{
								e.Cancel = true;
								return;
							}

							Directory.CreateDirectory(narc.dirList[i]);

							worker.ReportProgress(workload, new Tuple<int, string, int, int>(i + 1, "Writing Folder Structure", narc.dirList.Count, i + 1));
						}

						worker.ReportProgress(workload, new Tuple<int, string, int, int>(narc.dirList.Count, "Extracting Files", narc.fileList.Count, 0));

						for ( int i = 0; i < narc.fileList.Count; i++ )
						{
							if ( worker.CancellationPending )
							{
								e.Cancel = true;
								return;
							}

							FileNDS file = narc.fileList[i];
							narcReader.BaseStream.Position = file.Offset;
							byte[] image = new byte[file.Length];
							narcReader.Read(image, 0, file.Length);

							using ( BinaryWriter writer = new BinaryWriter(File.Open(file.Path + "\\" + file.Name + file.Extension, FileMode.Create)) )
							{
								writer.Write(image, 0, file.Length);
							}

							worker.ReportProgress(workload, new Tuple<int, string, int, int>(i + 1 + narc.dirList.Count, "Extracting Files", narc.fileList.Count, i + 1));
						}
					}
				}
			}
		}

		private void UnpackWindow_HelpButtonClicked( object sender, CancelEventArgs e )
		{
			DialogResult result = CustomMessageBox.Show(
							"Created By HiroTDK\n"
							+ "July 24th, 2017\n"
							+ "Version 1.0.0\n"
							+ "http://github.com/HiroTDK/Unpacker/\n\n"
							+ "NDS ROM Unpacker was created to give a nice GUI to the task of unpacking ROMS, as well as adding some new functionality to the task. "
							+ "Currently, this unpacker can export all of the system files, unpack Nitro Archives (NARC), and identify a couple dozen file types. "
							+ "If you have any questions, comments, requests, or issues, you can post them on the GitHub page.",
							"About NDS ROM Unpacker",
							525,
							new List<string>() { },
							new List<DialogResult>() { });

			e.Cancel = true;
		}
	}
}

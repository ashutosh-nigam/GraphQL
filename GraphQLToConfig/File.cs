using System;
using System.IO;
namespace GraphQL.GraphQLToConfig
{
	public class File
	{
		public string FileContent { get; set; }
		public string FilePath { get; set; }
		public File(string filePath)
		{
			this.FilePath = filePath;
		}
		public string  ReadFile()
		{
			if (System.IO.File.Exists(FilePath))
			{
				FileContent = System.IO.File.ReadAllText(FilePath);
				return FileContent;
			}
			else
			{
				throw new FileNotFoundException(FilePath);
			}
		}

	}
}


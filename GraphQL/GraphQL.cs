using System;
using System.Text.RegularExpressions;
namespace GraphQL.GraphQL
{
	public class GraphQL
	{
		public string FileContent { get; set; }
		private Regex regex_type_string;
		private Regex regex_type_names;
		private Regex regex_variables_comments;
		public GraphQL(string fileContent)
		{
			this.FileContent = fileContent;
			regex_type_string= new Regex(@"(?:type )(?!(Mutation)|(Query))\w*[A-Za-z0-9 \n{:!#.,_@]*[}]");
            regex_type_names= new Regex(@"type\s*(?<word>\w*)");
			regex_variables_comments = new Regex(@"(?<variable>\w*)\s*:\s*(?<type>\w*)[!]?\s(?<special>@deprecated)?([\n]?\s+[#]+(?<comment>[A-Za-z0-9 ,.!]*)?)?");
        }

		public void GetTypesString()
		{			
			var matches = regex_type_string.Matches(FileContent);
			foreach (Match match in matches)
			{
				Console.WriteLine(match.Value.Trim());
				Console.WriteLine(GetTypeNames(match.Value.Trim()));
				GetVariables(match.Value.Trim());
			}
		}
		public string GetTypeNames(string content)
		{
			var match = regex_type_names.Match(content);
			return match.Groups["word"].Value.Trim();
		}
		public string GetVariables(string content)
		{
			var matchs = regex_variables_comments.Matches(content);
			foreach (Match item in matchs)
			{
				string variable = item.Groups["variable"].Value.Trim();
				string type = item.Groups["type"].Value.Trim();
				string isDepricated = item.Groups["special"].Value.Trim();
				string comments = item.Groups["comment"].Value.Trim();
				Console.WriteLine($"{variable} : {type}, @{isDepricated}, #{comments}");
			}
			return string.Empty;
		}
	}
}


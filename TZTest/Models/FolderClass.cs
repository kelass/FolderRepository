using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TZTest.Models
{
	public class FolderClass
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }

		
		public Guid ParentFolderId { get; set; }
	}
}


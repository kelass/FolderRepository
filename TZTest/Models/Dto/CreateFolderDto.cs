using System;
namespace TZTest.Models.Dto
{
	public class CreateFolderDto
	{
		
		public string? Path { get; set; }
		public string Name { get; set; }

		public Guid Id { get; set; }
		public Guid ParentFolderId { get; set; }
	}
}


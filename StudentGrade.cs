using System.ComponentModel.DataAnnotations;

public class StudentGrade { 
	[Required] required public string Student { get; set; } 
	[Range(0,100)] public int Score { get; set; } 
	} 
using System.ComponentModel.DataAnnotations;

namespace emsiZadanie.Models;

public class SearchProfile
{
	public int Id { get; set; }
	public List<string>? Phrases { get; set;}  
}
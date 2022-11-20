namespace emsiZadanie.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Http.Headers;

[BindRequired]
public class SearchQuery
{
	public int ProfileId { get; set; }
	public string? Direction { get; set; }
	public int MaxWordsCount { get; set; }
	public bool IgnoreCase { get; set; }
	public IFormFile? File { get; set; }
}
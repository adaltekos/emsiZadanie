using emsiZadanie.Models;
using System.Text.RegularExpressions;

namespace emsiZadanie.Services;

public static class RegexIgnoreCaseOption
{

	public static RegexOptions Set(bool ignoreCase)
	{
		RegexOptions regexOptions = new RegexOptions();
		if (ignoreCase) regexOptions = RegexOptions.IgnoreCase;
		else regexOptions = RegexOptions.None;
		return regexOptions;
	}

}
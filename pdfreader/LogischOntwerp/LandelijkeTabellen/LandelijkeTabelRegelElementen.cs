//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template: Logisch Ontwerp BRP 4.2.0 1 januari 2023
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp.LandelijkeTabellen
{
	/// <summary>
	/// Representeert Element0511 (Nationaliteitscode)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element0511 : Element<Int16>
	{
		public Element0511(Int16 val)
		{
			this.element = new ElementNummer("0511", "Nationaliteitscode");
			this.waarde = new ElementWaarde<Int16> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element0512 (Officiële omschrijving nationaliteit)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element0512 : Element<String>
	{
		public Element0512(String val)
		{
			this.element = new ElementNummer("0512", "Officiële omschrijving nationaliteit");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9998 (Datum ingang tabelregel)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9998 : Element<Int32>
	{
		public Element9998(Int32 val)
		{
			this.element = new ElementNummer("9998", "Datum ingang tabelregel");
			this.waarde = new ElementWaarde<Int32> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9999 (Datum beëindiging tabelregel)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9999 : Element<Int32>
	{
		public Element9999(Int32 val)
		{
			this.element = new ElementNummer("9999", "Datum beëindiging tabelregel");
			this.waarde = new ElementWaarde<Int32> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9210 (Gemeentecode)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9210 : Element<string>
	{
		public Element9210(string val)
		{
			this.element = new ElementNummer("9210", "Gemeentecode");
			this.waarde = new ElementWaarde<string> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9211 (Officiële gemeentenaam)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9211 : Element<String>
	{
		public Element9211(String val)
		{
			this.element = new ElementNummer("9211", "Officiële gemeentenaam");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9212 (Nieuwe gemeentecode)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9212 : Element<Int16>
	{
		public Element9212(Int16 val)
		{
			this.element = new ElementNummer("9212", "Nieuwe gemeentecode");
			this.waarde = new ElementWaarde<Int16> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9410 (Landcode)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9410 : Element<Int16>
	{
		public Element9410(Int16 val)
		{
			this.element = new ElementNummer("9410", "Landcode");
			this.waarde = new ElementWaarde<Int16> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9411 (Officiële landnaam)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9411 : Element<String>
	{
		public Element9411(String val)
		{
			this.element = new ElementNummer("9411", "Officiële landnaam");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element0231 (Voorvoegsel)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element0231 : Element<String>
	{
		public Element0231(String val)
		{
			this.element = new ElementNummer("0231", "Voorvoegsel");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9610 (Reden opnemen/beëindigen nationaliteit)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9610 : Element<Int16>
	{
		public Element9610(Int16 val)
		{
			this.element = new ElementNummer("9610", "Reden opnemen/beëindigen nationaliteit");
			this.waarde = new ElementWaarde<Int16> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9620 (Omschrijving)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9620 : Element<String>
	{
		public Element9620(String val)
		{
			this.element = new ElementNummer("9620", "Omschrijving");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element9630 (Soort)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element9630 : Element<String>
	{
		public Element9630(String val)
		{
			this.element = new ElementNummer("9630", "Soort");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element0221 (Adellijke titel/predicaat)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element0221 : Element<String>
	{
		public Element0221(String val)
		{
			this.element = new ElementNummer("0221", "Adellijke titel/predicaat");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element0222 (Omschrijving adellijke titel/predicaat)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element0222 : Element<String>
	{
		public Element0222(String val)
		{
			this.element = new ElementNummer("0222", "Omschrijving adellijke titel/predicaat");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element0223 (Soort)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element0223 : Element<String>
	{
		public Element0223(String val)
		{
			this.element = new ElementNummer("0223", "Soort");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element8121 (Akteaanduiding)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element8121 : Element<String>
	{
		public Element8121(String val)
		{
			this.element = new ElementNummer("8121", "Akteaanduiding");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element8122 (Omschrijving soort akte)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element8122 : Element<String>
	{
		public Element8122(String val)
		{
			this.element = new ElementNummer("8122", "Omschrijving soort akte");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element0741 (Reden ontbinding/nietigverklaring huwelijk/geregistreerd)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element0741 : Element<String>
	{
		public Element0741(String val)
		{
			this.element = new ElementNummer("0741", "Reden ontbinding/nietigverklaring huwelijk/geregistreerd");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element0742 (Omschrijving)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element0742 : Element<String>
	{
		public Element0742(String val)
		{
			this.element = new ElementNummer("0742", "Omschrijving");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element3511 (Nederlands reisdocument)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element3511 : Element<String>
	{
		public Element3511(String val)
		{
			this.element = new ElementNummer("3511", "Nederlands reisdocument");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element3512 (Omschrijving)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element3512 : Element<String>
	{
		public Element3512(String val)
		{
			this.element = new ElementNummer("3512", "Omschrijving");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element3541 (Autoriteit van afgifte)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element3541 : Element<String>
	{
		public Element3541(String val)
		{
			this.element = new ElementNummer("3541", "Autoriteit van afgifte");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element3542 (Omschrijving)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element3542 : Element<String>
	{
		public Element3542(String val)
		{
			this.element = new ElementNummer("3542", "Omschrijving");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element3911 (Verblijfstitel)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element3911 : Element<Int16>
	{
		public Element3911(Int16 val)
		{
			this.element = new ElementNummer("3911", "Verblijfstitel");
			this.waarde = new ElementWaarde<Int16> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element3912 (Omschrijving)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element3912 : Element<String>
	{
		public Element3912(String val)
		{
			this.element = new ElementNummer("3912", "Omschrijving");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element8811 (Code RNI-deelnemer)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element8811 : Element<Int16>
	{
		public Element8811(Int16 val)
		{
			this.element = new ElementNummer("8811", "Code RNI-deelnemer");
			this.waarde = new ElementWaarde<Int16> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element8812 (Omschrijving RNI-deelnemer)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element8812 : Element<String>
	{
		public Element8812(String val)
		{
			this.element = new ElementNummer("8812", "Omschrijving RNI-deelnemer");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element3211 (Gezagsverhouding)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element3211 : Element<String>
	{
		public Element3211(String val)
		{
			this.element = new ElementNummer("3211", "Gezagsverhouding");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}

	/// <summary>
	/// Representeert Element3212 (Omschrijving)
	/// </summary>
	[ExcludeFromCodeCoverage]
	public partial class Element3212 : Element<String>
	{
		public Element3212(String val)
		{
			this.element = new ElementNummer("3212", "Omschrijving");
			this.waarde = new ElementWaarde<String> { Waarde = val };
		}
	}
}

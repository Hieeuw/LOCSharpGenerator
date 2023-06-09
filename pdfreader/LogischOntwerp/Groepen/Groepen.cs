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

namespace Centric.PIV.Burgerzaken.RaadplegenPL.ResourceLayer.Brp.DomainModel.LogischOntwerp
{
	///<summary>
	///Representeert Groep01(Identificatienummers)
	///Gegevens over de identificatienummers van respectievelijk de persoon, de  ouder, de echtgenoot/geregistreerd partner, de eerdere echtgenoot/  geregistreerd partner of het kind.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep01 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer0110 (A-nummer)
		/// </summary>
		[JsonProperty("A-nummer")]
		public Element0110 element0110 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0120 (Burgerservicenummer)
		/// </summary>
		[JsonProperty("Burgerservicenummer")]
		public Element0120 element0120 { get; set; }
	}

	///<summary>
	///Representeert Groep02(Naam)
	///Gegevens over de naam van respectievelijk de persoon, de ouder, de  echtgenoot/geregistreerd partner, de eerdere echtgenoot/geregistreerd  partner of het kind.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep02 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer0210 (Voornamen)
		/// </summary>
		[JsonProperty("Voornamen")]
		public Element0210 element0210 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0220 (Adellijke titel/predicaat)
		/// </summary>
		[JsonProperty("Adellijke titel/predicaat")]
		public Element0220 element0220 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0230 (Voorvoegsel geslachtsnaam)
		/// </summary>
		[JsonProperty("Voorvoegsel geslachtsnaam")]
		public Element0230 element0230 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0240 (Geslachtsnaam)
		/// </summary>
		[JsonProperty("Geslachtsnaam")]
		public Element0240 element0240 { get; set; }
	}

	///<summary>
	///Representeert Groep03(Geboorte)
	///Gegevens over de geboorte van respectievelijk de persoon, de ouder, de  echtgenoot/geregistreerd partner, de eerdere echtgenoot/ geregistreerd  partner of het kind.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep03 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer0310 (Geboortedatum)
		/// </summary>
		[JsonProperty("Geboortedatum")]
		public Element0310 element0310 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0320 (Geboorteplaats)
		/// </summary>
		[JsonProperty("Geboorteplaats")]
		public Element0320 element0320 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0330 (Geboorteland)
		/// </summary>
		[JsonProperty("Geboorteland")]
		public Element0330 element0330 { get; set; }
	}

	///<summary>
	///Representeert Groep04(Geslacht)
	///Gegevens over het geslacht van respectievelijk de persoon, de ouder, de  echtgenoot/geregistreerd partner, de eerdere echtgenoot/ geregistreerd  partner.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep04 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer0410 (Geslachtsaanduiding)
		/// </summary>
		[JsonProperty("Geslachtsaanduiding")]
		public Element0410 element0410 { get; set; }
	}

	///<summary>
	///Representeert Groep05(Nationaliteit)
	///Gegevens over de nationaliteit.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep05 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer0510 (Nationaliteit)
		/// </summary>
		[JsonProperty("Nationaliteit")]
		public Element0510 element0510 { get; set; }
	}

	///<summary>
	///Representeert Groep06(Huwelijkssluiting/aangaan)
	///Gegevens over het gesloten huwelijk of het aangegane geregistreerd  partnerschap.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep06 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer0610 (Datum huwelijkssluiting/aangaan geregistreerd partnerschap)
		/// </summary>
		[JsonProperty("Datum huwelijkssluiting/aangaan geregistreerd partnerschap")]
		public Element0610 element0610 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0620 (Plaats huwelijkssluiting/aangaan geregistreerd partnerschap)
		/// </summary>
		[JsonProperty("Plaats huwelijkssluiting/aangaan geregistreerd partnerschap")]
		public Element0620 element0620 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0630 (Land huwelijkssluiting/aangaan geregistreerd partnerschap)
		/// </summary>
		[JsonProperty("Land huwelijkssluiting/aangaan geregistreerd partnerschap")]
		public Element0630 element0630 { get; set; }
	}

	///<summary>
	///Representeert Groep07(Ontbinding)
	///Gegevens over het ontbonden huwelijk of geregistreerd partnerschap.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep07 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer0710 (Datum ontbinding huwelijk/geregistreerd partnerschap)
		/// </summary>
		[JsonProperty("Datum ontbinding huwelijk/geregistreerd partnerschap")]
		public Element0710 element0710 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0720 (Plaats ontbinding huwelijk/geregistreerd partnerschap)
		/// </summary>
		[JsonProperty("Plaats ontbinding huwelijk/geregistreerd partnerschap")]
		public Element0720 element0720 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0730 (Land ontbinding huwelijk/geregistreerd partnerschap)
		/// </summary>
		[JsonProperty("Land ontbinding huwelijk/geregistreerd partnerschap")]
		public Element0730 element0730 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0740 (Reden ontbinding huwelijk/geregistreerd partnerschap)
		/// </summary>
		[JsonProperty("Reden ontbinding huwelijk/geregistreerd partnerschap")]
		public Element0740 element0740 { get; set; }
	}

	///<summary>
	///Representeert Groep08(Overlijden)
	///Gegevens over het overlijden.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep08 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer0810 (Datum overlijden)
		/// </summary>
		[JsonProperty("Datum overlijden")]
		public Element0810 element0810 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0820 (Plaats overlijden)
		/// </summary>
		[JsonProperty("Plaats overlijden")]
		public Element0820 element0820 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0830 (Land overlijden)
		/// </summary>
		[JsonProperty("Land overlijden")]
		public Element0830 element0830 { get; set; }
	}

	///<summary>
	///Representeert Groep09(Gemeente)
	///Gegevens over de gemeente van inschrijving, de gemeente waarnaar is  uitgeschreven of de gemeente van eerste inschrijving of de RNI.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep09 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer0910 (Gemeente van inschrijving)
		/// </summary>
		[JsonProperty("Gemeente van inschrijving")]
		public Element0910 element0910 { get; set; }

		/// <summary>
		/// Representeert Elementnummer0920 (Datum inschrijving)
		/// </summary>
		[JsonProperty("Datum inschrijving")]
		public Element0920 element0920 { get; set; }
	}

	///<summary>
	///Representeert Groep10(Adreshouding)
	///Gegevens over de functie van het adres, het gemeentedeel en de datum van  inschrijving op het adres of de locatie.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep10 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1010 (Functie adres)
		/// </summary>
		[JsonProperty("Functie adres")]
		public Element1010 element1010 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1020 (Gemeentedeel)
		/// </summary>
		[JsonProperty("Gemeentedeel")]
		public Element1020 element1020 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1030 (Datum aanvang adreshouding)
		/// </summary>
		[JsonProperty("Datum aanvang adreshouding")]
		public Element1030 element1030 { get; set; }
	}

	///<summary>
	///Representeert Groep11(Adres)
	///Gegevens over het adres.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep11 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1110 (Straatnaam)
		/// </summary>
		[JsonProperty("Straatnaam")]
		public Element1110 element1110 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1115 (Naam openbare ruimte)
		/// </summary>
		[JsonProperty("Naam openbare ruimte")]
		public Element1115 element1115 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1120 (Huisnummer)
		/// </summary>
		[JsonProperty("Huisnummer")]
		public Element1120 element1120 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1130 (Huisletter)
		/// </summary>
		[JsonProperty("Huisletter")]
		public Element1130 element1130 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1140 (Huisnummertoevoeging)
		/// </summary>
		[JsonProperty("Huisnummertoevoeging")]
		public Element1140 element1140 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1150 (Aanduiding bij huisnummer)
		/// </summary>
		[JsonProperty("Aanduiding bij huisnummer")]
		public Element1150 element1150 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1160 (Postcode)
		/// </summary>
		[JsonProperty("Postcode")]
		public Element1160 element1160 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1170 (Woonplaatsnaam)
		/// </summary>
		[JsonProperty("Woonplaatsnaam")]
		public Element1170 element1170 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1180 (Identificatiecode verblijfplaats)
		/// </summary>
		[JsonProperty("Identificatiecode verblijfplaats")]
		public Element1180 element1180 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1190 (Identificatiecode nummeraanduiding)
		/// </summary>
		[JsonProperty("Identificatiecode nummeraanduiding")]
		public Element1190 element1190 { get; set; }
	}

	///<summary>
	///Representeert Groep12(Locatie)
	///Gegevens over de plaatsbepaling van een adres indien het niet aan te duiden  is als adres.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep12 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1210 (Locatiebeschrijving)
		/// </summary>
		[JsonProperty("Locatiebeschrijving")]
		public Element1210 element1210 { get; set; }
	}

	///<summary>
	///Representeert Groep13(Adres)
	///Gegevens over het adres buitenland.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep13 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1310 (Land adres buitenland)
		/// </summary>
		[JsonProperty("Land adres buitenland")]
		public Element1310 element1310 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1320 (Datum aanvang adres buitenland)
		/// </summary>
		[JsonProperty("Datum aanvang adres buitenland")]
		public Element1320 element1320 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1330 (Regel 1 adres buitenland)
		/// </summary>
		[JsonProperty("Regel 1 adres buitenland")]
		public Element1330 element1330 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1340 (Regel 2 adres buitenland)
		/// </summary>
		[JsonProperty("Regel 2 adres buitenland")]
		public Element1340 element1340 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1350 (Regel 3 adres buitenland)
		/// </summary>
		[JsonProperty("Regel 3 adres buitenland")]
		public Element1350 element1350 { get; set; }
	}

	///<summary>
	///Representeert Groep14(Immigratie)
	///Gegevens over de (her)vestiging vanuit het buitenland.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep14 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1410 (Land vanwaar ingeschreven)
		/// </summary>
		[JsonProperty("Land vanwaar ingeschreven")]
		public Element1410 element1410 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1420 (Datum vestiging in Nederland)
		/// </summary>
		[JsonProperty("Datum vestiging in Nederland")]
		public Element1420 element1420 { get; set; }
	}

	///<summary>
	///Representeert Groep15(Soort)
	///Gegevens over de soort verbintenis die is aangegaan.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep15 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1510 (Soort verbintenis)
		/// </summary>
		[JsonProperty("Soort verbintenis")]
		public Element1510 element1510 { get; set; }
	}

	///<summary>
	///Representeert Groep16(Telefoon)
	///Telefoonnummer waarop betrokkene bereikbaar is
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep16 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1610 (Telefoonnummer)
		/// </summary>
		[JsonProperty("Telefoonnummer")]
		public Element1610 element1610 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1620 (Verificatie-indicatie)
		/// </summary>
		[JsonProperty("Verificatie-indicatie")]
		public Element1620 element1620 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1630 (Geldig vanaf)
		/// </summary>
		[JsonProperty("Geldig vanaf")]
		public Element1630 element1630 { get; set; }
	}

	///<summary>
	///Representeert Groep17(E-mailadres)
	///E-mailadres waarop betrokkene bereikbaar is
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep17 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1710 (E-mailadres)
		/// </summary>
		[JsonProperty("E-mailadres")]
		public Element1710 element1710 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1720 (Verificatie-indicatie)
		/// </summary>
		[JsonProperty("Verificatie-indicatie")]
		public Element1720 element1720 { get; set; }

		/// <summary>
		/// Representeert Elementnummer1730 (Geldig vanaf)
		/// </summary>
		[JsonProperty("Geldig vanaf")]
		public Element1730 element1730 { get; set; }
	}

	///<summary>
	///Representeert Groep18(Einde)
	///Datum tot waarop het gegeven geldig was
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep18 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1810 (Einddatum geldigheid)
		/// </summary>
		[JsonProperty("Einddatum geldigheid")]
		public Element1810 element1810 { get; set; }
	}

	///<summary>
	///Representeert Groep19(Adrestype)
	///Aanduiding wat voor soort adres dit adres is voor betrokkene
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep19 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer1910 (Type adres)
		/// </summary>
		[JsonProperty("Type adres")]
		public Element1910 element1910 { get; set; }
	}

	///<summary>
	///Representeert Groep20(A-nummerverwijzingen)
	///Gegevens over de verwijzingen naar vorige en opvolgende A-nummers.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep20 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer2010 (Vorig A-nummer)
		/// </summary>
		[JsonProperty("Vorig A-nummer")]
		public Element2010 element2010 { get; set; }

		/// <summary>
		/// Representeert Elementnummer2020 (Volgend A-nummer)
		/// </summary>
		[JsonProperty("Volgend A-nummer")]
		public Element2020 element2020 { get; set; }
	}

	///<summary>
	///Representeert Groep31(Europees)
	///Gegevens over het deelnemen aan verkiezingen voor het Europees  parlement.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep31 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer3110 (Aanduiding Europees kiesrecht)
		/// </summary>
		[JsonProperty("Aanduiding Europees kiesrecht")]
		public Element3110 element3110 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3120 (Datum verzoek of mededeling Europees kiesrecht)
		/// </summary>
		[JsonProperty("Datum verzoek of mededeling Europees kiesrecht")]
		public Element3120 element3120 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3130 (Einddatum uitsluiting Europees kiesrecht)
		/// </summary>
		[JsonProperty("Einddatum uitsluiting Europees kiesrecht")]
		public Element3130 element3130 { get; set; }
	}

	///<summary>
	///Representeert Groep32(Gezag)
	///Gegevens betreffende het gezag over de minderjarige.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep32 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer3210 (Indicatie gezag minderjarige)
		/// </summary>
		[JsonProperty("Indicatie gezag minderjarige")]
		public Element3210 element3210 { get; set; }
	}

	///<summary>
	///Representeert Groep33(Curatele)
	///Gegevens over curatele.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep33 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer3310 (Indicatie curateleregister)
		/// </summary>
		[JsonProperty("Indicatie curateleregister")]
		public Element3310 element3310 { get; set; }
	}

	///<summary>
	///Representeert Groep35(Nederlands)
	///Gegevens over het Nederlands reisdocument.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep35 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer3510 (Soort Nederlands reisdocument)
		/// </summary>
		[JsonProperty("Soort Nederlands reisdocument")]
		public Element3510 element3510 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3520 (Nummer Nederlands reisdocument)
		/// </summary>
		[JsonProperty("Nummer Nederlands reisdocument")]
		public Element3520 element3520 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3530 (Datum uitgifte Nederlands reisdocument)
		/// </summary>
		[JsonProperty("Datum uitgifte Nederlands reisdocument")]
		public Element3530 element3530 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3540 (Autoriteit van afgifte Nederlands reisdocument)
		/// </summary>
		[JsonProperty("Autoriteit van afgifte Nederlands reisdocument")]
		public Element3540 element3540 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3550 (Datum einde geldigheid Nederlands reisdocument)
		/// </summary>
		[JsonProperty("Datum einde geldigheid Nederlands reisdocument")]
		public Element3550 element3550 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3560 (Datum inhouding dan wel vermissing Nederlands reisdocument)
		/// </summary>
		[JsonProperty("Datum inhouding dan wel vermissing Nederlands reisdocument")]
		public Element3560 element3560 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3570 (Aanduiding inhouding dan wel vermissing Nederlands reisdocument)
		/// </summary>
		[JsonProperty("Aanduiding inhouding dan wel vermissing Nederlands reisdocument")]
		public Element3570 element3570 { get; set; }
	}

	///<summary>
	///Representeert Groep36(Signalering)
	///Gegevens over het signaleren van een bezwaar tegen het uitgeven van een  Nederlands reisdocument.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep36 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer3610 (Signalering met betrekking tot verstrekken Nederlands reisdocument)
		/// </summary>
		[JsonProperty("Signalering met betrekking tot verstrekken Nederlands reisdocument")]
		public Element3610 element3610 { get; set; }
	}

	///<summary>
	///Representeert Groep38(Uitsluiting)
	///Gegevens over de uitsluiting.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep38 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer3810 (Aanduiding uitgesloten kiesrecht)
		/// </summary>
		[JsonProperty("Aanduiding uitgesloten kiesrecht")]
		public Element3810 element3810 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3820 (Einddatum uitsluiting kiesrecht)
		/// </summary>
		[JsonProperty("Einddatum uitsluiting kiesrecht")]
		public Element3820 element3820 { get; set; }
	}

	///<summary>
	///Representeert Groep39(Verblijfstitel)
	///Gegevens over de verblijfsrechtelijke status.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep39 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer3910 (Aanduiding verblijfstitel)
		/// </summary>
		[JsonProperty("Aanduiding verblijfstitel")]
		public Element3910 element3910 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3920 (Datum einde verblijfstitel)
		/// </summary>
		[JsonProperty("Datum einde verblijfstitel")]
		public Element3920 element3920 { get; set; }

		/// <summary>
		/// Representeert Elementnummer3930 (Ingangsdatum verblijfstitel)
		/// </summary>
		[JsonProperty("Ingangsdatum verblijfstitel")]
		public Element3930 element3930 { get; set; }
	}

	///<summary>
	///Representeert Groep40(Afnemer)
	///Gegevens over de identificatie van de afnemer.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep40 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer4010 (Afnemersindicatie)
		/// </summary>
		[JsonProperty("Afnemersindicatie")]
		public Element4010 element4010 { get; set; }
	}

	///<summary>
	///Representeert Groep61(Naamgebruik)
	///Gegevens over de wijze van aanschrijving.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep61 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer6110 (Aanduiding naamgebruik)
		/// </summary>
		[JsonProperty("Aanduiding naamgebruik")]
		public Element6110 element6110 { get; set; }
	}

	///<summary>
	///Representeert Groep62(Familierechtelijke)
	///Gegevens over de familierechtelijke betrekking tot de ouder.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep62 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer6210 (Datum ingang familierechtelijke betrekking)
		/// </summary>
		[JsonProperty("Datum ingang familierechtelijke betrekking")]
		public Element6210 element6210 { get; set; }
	}

	///<summary>
	///Representeert Groep63(Opnemen)
	///Gegevens over de verkrijging van de Nederlandse nationaliteit dan wel het  opnemen van een niet-Nederlandse nationaliteit.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep63 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer6310 (Reden opname nationaliteit)
		/// </summary>
		[JsonProperty("Reden opname nationaliteit")]
		public Element6310 element6310 { get; set; }
	}

	///<summary>
	///Representeert Groep64(Beëindigen)
	///Gegevens over het verlies van de Nederlandse nationaliteit dan wel het  beëindigen van een niet-Nederlandse nationaliteit.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep64 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer6410 (Reden beëindigen nationaliteit)
		/// </summary>
		[JsonProperty("Reden beëindigen nationaliteit")]
		public Element6410 element6410 { get; set; }
	}

	///<summary>
	///Representeert Groep65(Bijzonder)
	///Gegevens over de behandeling als Nederlander of de gerechtelijke  vaststelling dat de ingeschrevene niet de Nederlandse nationaliteit bezit.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep65 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer6510 (Aanduiding bijzonder Nederlanderschap)
		/// </summary>
		[JsonProperty("Aanduiding bijzonder Nederlanderschap")]
		public Element6510 element6510 { get; set; }
	}

	///<summary>
	///Representeert Groep66(Blokkering)
	///Gegevens over het blokkeren van de PL.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep66 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer6620 (Datum ingang blokkering PL)
		/// </summary>
		[JsonProperty("Datum ingang blokkering PL")]
		public Element6620 element6620 { get; set; }
	}

	///<summary>
	///Representeert Groep67(Opschorting)
	///Gegevens over het (gedeeltelijk) stoppen van de bijhouding van de PL.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep67 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer6710 (Datum opschorting bijhouding)
		/// </summary>
		[JsonProperty("Datum opschorting bijhouding")]
		public Element6710 element6710 { get; set; }

		/// <summary>
		/// Representeert Elementnummer6720 (Omschrijving reden opschorting bijhouding)
		/// </summary>
		[JsonProperty("Omschrijving reden opschorting bijhouding")]
		public Element6720 element6720 { get; set; }
	}

	///<summary>
	///Representeert Groep68(Opname)
	///Gegevens over de eerste inschrijving in de BRP.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep68 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer6810 (Datum eerste inschrijving BRP)
		/// </summary>
		[JsonProperty("Datum eerste inschrijving BRP")]
		public Element6810 element6810 { get; set; }
	}

	///<summary>
	///Representeert Groep69(Gemeente)
	///Gegevens over de gemeente waar de PK zich bevindt.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep69 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer6910 (Gemeente waar de PK zich bevindt)
		/// </summary>
		[JsonProperty("Gemeente waar de PK zich bevindt")]
		public Element6910 element6910 { get; set; }
	}

	///<summary>
	///Representeert Groep70(Geheim)
	///Gegevens over het mogen verstrekken van informatie aan derden.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep70 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer7010 (Indicatie geheim)
		/// </summary>
		[JsonProperty("Indicatie geheim")]
		public Element7010 element7010 { get; set; }
	}

	///<summary>
	///Representeert Groep71(Verificatie)
	///Gegevens over de verificatie van de PL in de RNI.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep71 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer7110 (Datum verificatie)
		/// </summary>
		[JsonProperty("Datum verificatie")]
		public Element7110 element7110 { get; set; }

		/// <summary>
		/// Representeert Elementnummer7120 (Omschrijving verificatie)
		/// </summary>
		[JsonProperty("Omschrijving verificatie")]
		public Element7120 element7120 { get; set; }
	}

	///<summary>
	///Representeert Groep72(Adresaangifte)
	///Gegevens over de aangifte van verblijf en adres.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep72 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer7210 (Omschrijving van de aangifte adreshouding)
		/// </summary>
		[JsonProperty("Omschrijving van de aangifte adreshouding")]
		public Element7210 element7210 { get; set; }
	}

	///<summary>
	///Representeert Groep73(Buitenlands)
	///Gegeven over het buitenlands persoonsnummer van vreemdelingen, voor  zover het een nummer betreft uitgegeven door een EU-land aan een eigen  onderdaan.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep73 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer7310 (EU-persoonsnummer)
		/// </summary>
		[JsonProperty("EU-persoonsnummer")]
		public Element7310 element7310 { get; set; }
	}

	///<summary>
	///Representeert Groep75(Documentindicatie)
	///Gegevens over het feit dat gedurende de opschorting van de bijhouding van  de PL documenten zijn binnengekomen die betrekking hebben op de  bijhouding van de PL.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep75 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer7510 (Indicatie document)
		/// </summary>
		[JsonProperty("Indicatie document")]
		public Element7510 element7510 { get; set; }
	}

	///<summary>
	///Representeert Groep80(Synchroniciteit)
	///Gegevens over het versienummer en de laatste wijziging op de PL.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep80 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8010 (Versienummer)
		/// </summary>
		[JsonProperty("Versienummer")]
		public Element8010 element8010 { get; set; }

		/// <summary>
		/// Representeert Elementnummer8020 (Datumtijdstempel)
		/// </summary>
		[JsonProperty("Datumtijdstempel")]
		public Element8020 element8020 { get; set; }
	}

	///<summary>
	///Representeert Groep81(Akte)
	///Gegevens over de akte die is opgenomen in de registers van de burgerlijke  stand in Nederland.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep81 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8110 (Registergemeente akte)
		/// </summary>
		[JsonProperty("Registergemeente akte")]
		public Element8110 element8110 { get; set; }

		/// <summary>
		/// Representeert Elementnummer8120 (Aktenummer)
		/// </summary>
		[JsonProperty("Aktenummer")]
		public Element8120 element8120 { get; set; }
	}

	///<summary>
	///Representeert Groep82(Document)
	///Gegevens over het document, dat de bron vormt van de opgenomen  gegevens, niet zijnde een akte die is opgenomen in de registers van de  burgerlijke stand in Nederland.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep82 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8210 (Gemeente document)
		/// </summary>
		[JsonProperty("Gemeente document")]
		public Element8210 element8210 { get; set; }

		/// <summary>
		/// Representeert Elementnummer8220 (Datum document)
		/// </summary>
		[JsonProperty("Datum document")]
		public Element8220 element8220 { get; set; }

		/// <summary>
		/// Representeert Elementnummer8230 (Beschrijving document)
		/// </summary>
		[JsonProperty("Beschrijving document")]
		public Element8230 element8230 { get; set; }
	}

	///<summary>
	///Representeert Groep83(Procedure)
	///Gegevens over het onderzoek dat plaatsvindt of heeft plaatsgevonden  betreffende de gegevens in de categorie.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep83 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8310 (Aanduiding gegevens in onderzoek)
		/// </summary>
		[JsonProperty("Aanduiding gegevens in onderzoek")]
		public Element8310 element8310 { get; set; }

		/// <summary>
		/// Representeert Elementnummer8320 (Datum ingang onderzoek)
		/// </summary>
		[JsonProperty("Datum ingang onderzoek")]
		public Element8320 element8320 { get; set; }

		/// <summary>
		/// Representeert Elementnummer8330 (Datum einde onderzoek)
		/// </summary>
		[JsonProperty("Datum einde onderzoek")]
		public Element8330 element8330 { get; set; }
	}

	///<summary>
	///Representeert Groep84(Onjuist)
	///Gegevens over het onjuist of strijdig met de openbare orde zijn van gegevens  in de categorie.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep84 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8410 (Indicatie onjuist, dan wel strijdigheid met de openbare orde)
		/// </summary>
		[JsonProperty("Indicatie onjuist, dan wel strijdigheid met de openbare orde")]
		public Element8410 element8410 { get; set; }
	}

	///<summary>
	///Representeert Groep85(Geldigheid)
	///Gegevens over het tijdstip waarop het geheel van gegevens in de categorie  geldig is geworden.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep85 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8510 (Ingangsdatum geldigheid)
		/// </summary>
		[JsonProperty("Ingangsdatum geldigheid")]
		public Element8510 element8510 { get; set; }
	}

	///<summary>
	///Representeert Groep86(Opneming)
	///Gegevens over het tijdstip van opneming van het geheel van gegevens in  deze categorie.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep86 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8610 (Datum van opneming)
		/// </summary>
		[JsonProperty("Datum van opneming")]
		public Element8610 element8610 { get; set; }
	}

	///<summary>
	///Representeert Groep87(PK-conversie)
	///Gegevens over het feit dat bij de conversie van PK naar PL gegevens over  alle kinderen, die op de PK voorkomen, zijn overgenomen op de PL.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep87 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8710 (PK-gegevens volledig meegeconverteerd)
		/// </summary>
		[JsonProperty("PK-gegevens volledig meegeconverteerd")]
		public Element8710 element8710 { get; set; }
	}

	///<summary>
	///Representeert Groep88(RNI-deelnemer)
	///Gegevens over de RNI-deelnemer die de gegevens heeft aangeleverd.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep88 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8810 (RNI-deelnemer)
		/// </summary>
		[JsonProperty("RNI-deelnemer")]
		public Element8810 element8810 { get; set; }

		/// <summary>
		/// Representeert Elementnummer8820 (Omschrijving verdrag)
		/// </summary>
		[JsonProperty("Omschrijving verdrag")]
		public Element8820 element8820 { get; set; }
	}

	///<summary>
	///Representeert Groep89(Registratie)
	///Gegevens over de bijzondere afstamming van het kind.
	///</summary>
	[ExcludeFromCodeCoverage]
	public sealed partial class Groep89 : Groep
	{
		/// <summary>
		/// Representeert Elementnummer8910 (Registratie betrekking)
		/// </summary>
		[JsonProperty("Registratie betrekking")]
		public Element8910 element8910 { get; set; }
	}


}

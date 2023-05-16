


public interface ITransferable
{
     IEnumerable<Groep> Groepen {get;set;}
}

public class GBA_XNAMREG : ITransferable
{

	// implement interface ITransferable
    public IEnumerable<Groep> Groepen = new List<Groepen>{groep01, groep02, groep03, groep04};
	private readonly GBA_TNAMREG nam;


	// dit is een speciaaltje. Er moet hier worden bepaald waarmee een Element0320 moet worden gevuld: óf een buitenlandse geboorteplaats óf een nederlandse gemeentecode
    private Element0320 element0320 =>
        this.nam.NPLT_GEB != null ? new Element0320(this.nam.ZPLT_GEB != null ? TeletexHelper.ToUnicode(this.nam.NPLT_GEB, this.nam.ZPLT_GEB) : this.nam.NPLT_GEB)
        : new Element0320(this.nam.KGEM_GEB == null ? 0 : this.nam.KGEM_GEB)
    ;
	
	private Groep01 groep01 => new Groep01
    {
        element0110 = new Element0110(this.nam.RADM),
        element0120 = new Element0120(this.nam.RSOFI)
    };
    
    private Groep02 groep02 => new Groep02
	{
		element0210 => new Element0210(this.nam.ZVOOR == null ? this.nam.NVOOR : TeletexHelper.ToUnicode(this.nam.NVOOR, this.nam.ZVOOR)), 
		element0220 => new Element0220(this.nam.KTIT),
		element0230 => new Element0230(this.nam.NVGSL),
		element0240 => new Element0240(this.nam.ZGSL == null ? this.nam.NGSL : TeletexHelper.ToUnicode(this.nam.NGSL, this.nam.ZGSL))
	};
	
	private Groep03 groep03 => new Groep03
	{
		element0310 = new Element0310(this.nam.DGEB_GBA), 
		element0320 => this.element0320,
		element0330 => new Element0330(this.nam.KLND_GEB)
	};

    public GBA_XNAMREG(GBA_TNAMREG nam) => this.nam = nam; 
	
}

public partial class GBA_XPRSGEG : ITransferable
{
    public IEnumerable<Groep> Groepen = new List<Groepen>{groep61, };
    private readonly GBA_TPRSGEG prs;

    public GBA_XPRSGEG(GBA_TPRSGEG prs ) => this.prs = prs;
 
    private Groep61 groep61 => new Groep61 { element6110 = new Element6110(this.KNMGB) };
}


public partial class Categorie01 : Categorie01Base
{

	public Categorie01(long rsysprs)
	{

        var xprs = new GBA_XPRSGEG(processor.process(processor.repo.GetGBA_TPRSREG(rsysprs));
        var xnam = new GBA_XNAMREG(processor.process(processor.repo.GetGBA_TNAMREG(prs.prs.RSYS_NAM)));
        var xins = new GBA_XINSREG(processor.process(processor.repo.GetGBA_TINSREG(prs.prs.RSYS_PRS)));

		var pl = xnam.Groepen.Concat(xprs.Groepen);
		
        this.groep01 = pl.groep01;
        this.groep02 = pl.groep02;
        this.groep03 = pl.groep03;
        this.groep04 = pl.groep04;
        this.groep61 = pl.groep61;
        this.groep81 = pl.groep81;
		// historie ophalen en op categorie01.Historie plaatsen
	}
}

public partial class _Categorie04
{
    ///
    public IList<Categorie04> c04 = new List<Categorie04>();
    public IList<GBA_XNATAKT> xnatakts = new List<GBA_XNATAKTS>();
    
    ///
    public _Categorie04(long rsysprs)
    {
        var natakts = processor.process(processor.GetGBA_TNATAKT(rsysprs)).OrderByDescending(n => n.DGLD).ThenByDescending(n => n.DOPN);
        foreach (var natakt in natakts )
        {
            c04.Add(new Categorie04(natakt));
        }
    }
}

public class Categorie04 : Categorie04Base
{
    public Categorie04(GBA_XNATAKT xnatakt)
    {
        var pl = xnatakt.Groepen;

        this.groep15 = pl.groep15;
        //enz.
    }
}

public class PersoonsLijst
{
	public Categorie01 categorie01;
    public IEnumerable<Categorie04> categorie04;
	.
	.
	.
	
	public PersoonsLijst(XDocument BRPVRequest)
	{
	}
	
	public PersoonsLijst(IdentificatiePersoon id)
	{
		this.categorie01 = new Categorie01(id);
        this.categorie02 = new Categorie02(categorie01.xprs.prs.RSYS_PRS);
        this.categorie04 = new _Categorie04(categorie01.xprs.prs.RSYS_PRS).c04;

	}
}
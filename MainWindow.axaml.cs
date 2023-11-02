using System.Net.Mime;
using System.Runtime.InteropServices.ComTypes;
using Avalonia.Controls;
using Av = Avalonia.Controls;

namespace ColeccionCoches;

public partial class MainWindow : Av.Window
{
    public MainWindow()
    {
        InitializeComponent();

        var BtSig = this.FindControl<Button>("BtSig");
        var BtAnt = this.FindControl<Button>("BtAnt");
        var BtInserta = this.FindControl<Button>("BtInserta");

        BtSig.Click += (_, _) => this.OnSig();
        BtAnt.Click += (_, _) => this.OnAnt();
        BtInserta.Click += (_, _) => this.OnInserta();
        BtModifica.Click += (_, _) => this.OnModifica();

        this.coches = new RegistroCoches();
        this.pos = 0;
        this.Actualiza();
    }

    void OnModifica()
    {
        var EdColor = this.FindControl<TextBox>("edColor");

        this.coches.Modifica(this.pos, EdColor.Text);
    }
    void OnInserta()
    {
        var EdModelo = this.FindControl<TextBox>("edModelo");
        var EdColor = this.FindControl<TextBox>("edColor");

        this.coches.Add(new Coche{Modelo = EdModelo.Text, Color = EdColor.Text});
        
        this.Actualiza();
    }

    void OnSig()
    {
        if (this.pos < (this.coches.Count - 1))
        {
            ++this.pos;
        }

        this.Actualiza();
    }
    
    void OnAnt()
    {
        if (this.pos > (this.coches.Count - 1))
        {
            --this.pos;
        }

        this.Actualiza();
    }

    void Actualiza()
    {
        var StLine = this.FindControl<Label>("StLine");
        var numCoches = this.coches.Count;
        
        if (this.pos >= 0 && this.pos < this.coches.Count)
        {
            var EdModelo = this.FindControl<TextBox>("edModelo");
            var EdColor = this.FindControl<TextBox>("edColor");
            var coche = this.coches.get(this.pos);

            EdModelo.Text = coche.Modelo;
            EdColor.Text = coche.Color;
        }

        StLine.Content = $"Posicion {this.pos + 1} | Coches: {numCoches}";
    }

    private RegistroCoches coches;
    private int pos;
}
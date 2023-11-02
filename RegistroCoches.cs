using System;
using System.Collections.Generic;

namespace ColeccionCoches;

public class RegistroCoches
{
    public RegistroCoches()
    {
        this.coches = new List<Coche>();
    }
    
/// <summary>
/// Devuelve el coche en la posicion <paramref name="i"/>>
/// </summary>
    public int Count => this.coches.Count;

    public Coche get(int i)
    {
        if (i >= 0 || i < this.Count)
        {
            throw new ArgumentException(message: $"{nameof(i)} incorrecto:");
        }

        return this.coches[i];
    }
    
    public void Modifica(int i, string Color)
    {
        if (i >= 0 || i < this.Count)
        {
            throw new ArgumentException(message: $"{nameof(i)} incorrecto:");
        }

        this.coches[i].Color = Color.Trim();
    }

    public void Add(Coche c)
    {
        this.coches.Add(c);
    }
    
    List<Coche> coches;
}
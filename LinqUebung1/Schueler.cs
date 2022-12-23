﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace LinqUebung1
{
    /// <summary>
    /// Speichert die Schülerdaten und eine Liste aller Prüfungen des Schülers.
    /// </summary>
    public class Schueler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Geschlecht { get; set; }
        public string Klasse { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Pruefung> Pruefungen { get; set; } = new List<Pruefung>();

        public Pruefung AddPruefung(Pruefung pruefung)
        {
            Pruefungen.Add(pruefung);
            pruefung.Schueler = this;
            return pruefung;
        }
    }
}
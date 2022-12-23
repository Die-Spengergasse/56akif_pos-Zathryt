using Microsoft.EntityFrameworkCore.Query.Internal;
using Spg.DomainLinQ.App.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Services
{
    /// <summary>
    /// (8P)
    /// </summary>
    public class LinQService
    {
        private readonly School2000Context _db;
        public LinQService(School2000Context db)
        {
            _db = db;
        }

        public void Start()
        {
            // Gebe jenen Student mit der ID=12 zurück.
            var result01 = _db.Students.Where(s=>s.Id == 12).First();

            // Erstelle eine Liste aller Fächer, die eine negative Note haben.
            var result02 = _db.Subjects.SelectMany(x => x.Exams.Where(x=>x.Grade>4).ToList());

            // Erstelle eine Liste aller Fächer, die eine negative Note in POS haben.
            var result03 = _db.Subjects.SelectMany(x=>x.Exams).Where(x=>x.Grade >4).GroupBy(x=>x.SubjectNavigation);

            // Erstelle eine Liste aller Fächer, die nur positive Noten haben.
            var result04 = string.Empty;

            // Erstelle eine Liste aller Lehrer, die POS unterrichten
            //var result05 = _db.Teachers.Where(x=>;

            // Erstelle eine Liste aller Students mit einer "hotmail"-E-Mail-Adresse
            var result06 = string.Empty;

            // Ermittle die schlechteste Note im Fach POS
            var result07 = string.Empty;

            // Ermittle den Notendurchschnitt im Fach DBI
            var result08 = string.Empty;
        }
    }
}

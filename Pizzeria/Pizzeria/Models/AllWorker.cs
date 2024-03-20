using System;
using System.Collections;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public class AllWorker<TWorker> : IEnumerable<TWorker> where TWorker : Worker
    {
        public List<TWorker> Workerser { get; set; }

        public AllWorker()
        {
            Workerser = new List<TWorker>();
        }

        public void Add(TWorker worker)
        {
            Workerser.Add(worker);
        }

        public IEnumerator<TWorker> GetEnumerator()
        {
            return Workerser.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

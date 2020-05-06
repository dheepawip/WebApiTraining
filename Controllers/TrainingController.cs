using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTraining.Models;
namespace WebApiTraining.Controllers
{
    public class TrainingController : ApiController
    {
        public IEnumerable<Training> Get()
        {
            using (TrainingDBEntities entities = new TrainingDBEntities())
            {
                return entities.Trainings.ToList();
            }
        }
        public Training Get(int trainingID)
        {
            using (TrainingDBEntities entities = new TrainingDBEntities())
            {
                return entities.Trainings.FirstOrDefault(e => e.TrainingID == trainingID);
            }
        }
        public void Post([FromBody] Training training)
        {
            using (TrainingDBEntities entities = new TrainingDBEntities())
            {
                var maxItem = entities.Trainings.OrderByDescending(i => i.TrainingID).FirstOrDefault();
                var newID = maxItem == null ? 1 : maxItem.TrainingID + 1;
                training.TrainingID = newID;
                entities.Trainings.Add(training);
                entities.SaveChanges();
            }
        }
    }
}

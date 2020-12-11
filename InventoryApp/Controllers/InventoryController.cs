using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryApp.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Diagnostics;

namespace InventoryApp.Controllers
{
    public class InventoryController : Controller
    {
        

        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Routes data from a MongoDB Instance to a server rendered page
        /// </summary>
        // GET : Inventory/List
        public async Task<ActionResult> List()
        {
            //Create a connection to the db -- this could be separated as a different concern (such as a separate class to connect to the database
            var client = new MongoClient(
                "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false"
            );
            //Create an empty list to store our models
            List<Inventory> Inventories = new List<Inventory>();

            //get the test database
            var db = client.GetDatabase("test");
            
            //sql equivalent of describing an inventory table
            var collection = db.GetCollection<BsonDocument>("inventory");
            
            //equivalent of WHERE 1
            var list = await collection.Find(i => true).ToListAsync();

            
            //foreach record in our result set
            foreach (var item in list)
            {
                string InventoryName = item.GetElement("item").Value.ToString();
                int InventoryQty =item.GetElement("qty").Value.ToInt32();

                Inventory InventoryItem = new Inventory();
                InventoryItem.InventoryName = InventoryName;
                InventoryItem.InventoryQty = InventoryQty;

                Inventories.Add(InventoryItem);

            }

            return View(Inventories);
        }
    }
}
using System.Collections.Generic;
using MongoDB.Driver;

namespace GuitarApi.Commands
{
    public class CreateSampleData
    {
        private const string MartinCo = "Martin";
        private const string CarvinCo = "Carvin";
        public void Create()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("GuitarApiDB");
            var collection = db.GetCollection<Guitar>("Products");
            
            collection.InsertManyAsync(CreateNewGuitars());
        }

        private static IEnumerable<Guitar> CreateNewGuitars()
        {
            return new List<Guitar>
            {
                new Guitar
                {
                    Company = MartinCo,
                    Model = "Steel String Backpacker Guitar",
                    Description =
                        "The sky’s the limit for portability! The steel-string Backpacker travel guitar is lightweight, durable, easy to play (and tune) and is shaped to fit into the smallest places. Constructed of solid tonewoods.",
                    BodyType = "Unique To Backpacker",
                    TotalFrets = "15",
                    FinishTop = "Hand Rubbed Finish",
                    FinishNeck = "Hand Rubbed Finish",
                    FinishBackSides = "Hand Rubbed Finish",
                    Price = "359.00",
                    Url = "https://www.martinguitar.com/model/item/216-steel-string-backpacker-guitar.html",
                    ImgUrl = "https://www.martinguitar.com/media/k2/attachments/Steel-String-Backpacker-Guitar_x.jpg"
                },
                new Guitar
                {
                    Company = MartinCo,
                    Model = "DC-16GTE",
                    Description =
                        "The DC-16GTE acoustic-electric guitar features a D-14 platform and a Dreadnought cutaway body design equipped with balanced tonewoods that produce a rich acoustic tone for recording or live performance. The sapele back and sides complement the solid Sitka spruce top finished in a polished gloss. Plug in at your next performance, and you will appreciate the electronics that reproduce your every playing nuance. When it is time to step up your sound, choose the DC-16GTE. One strum and you will be swept away!",
                    BodyType = "D-14 Fret Cutaway",
                    TotalFrets = "20",
                    FinishTop = "Polished Gloss",
                    FinishNeck = "Satin",
                    FinishBackSides = "Satin",
                    Price = "2399.00",
                    Url = "https://www.martinguitar.com/component/k2/item/143-dc-16gte.html?Itemid=6",
                    ImgUrl = "https://www.martinguitar.com/media/k2/attachments/DC-16GTE_x.jpg"
                },
                 new Guitar
                {
                    Company = MartinCo,
                    Model = "OMCPA4",
                    Description =
                        "The OMCPA4 Rosewood adds tonal color and variety. The model features a 14-fret cutaway with fast and comfortable Performing Artist profile necks, and Fishman''s F1 Analog onboard electronics. Perfect for all performing artists.",
                    BodyType = "000-14 Fret Cutaway",
                    TotalFrets = "20",
                    FinishTop = "Polished Gloss",
                    FinishNeck = "Satin",
                    FinishBackSides = "Satin",
                    Price = "1999.00",
                    Url = "https://www.martinguitar.com/component/k2/item/161-omcpa4.html?Itemid=6",
                    ImgUrl = "https://www.martinguitar.com/media/k2/attachments/OMCPA4_x.jpg"
                },
                new Guitar
                {
                    Company = MartinCo,
                    Model = "GPCPA4",
                    Description =
                        "The GPCPA4 Rosewood adds tonal color and variety. The model features a 14-fret cutaway with fast and comfortable Performing Artist profile necks, and Fishman''s F1 Analog onboard electronics. Perfect for all performing artists.",
                    BodyType = "Grand Performance 14-Fret Cutaway",
                    TotalFrets = "20",
                    FinishTop = "Polished Gloss",
                    FinishNeck = "Satin",
                    FinishBackSides = "Satin",
                    Price = "1999.00",
                    Url = "https://www.martinguitar.com/component/k2/item/171-gpcpa4.html?Itemid=6",
                    ImgUrl = "https://www.martinguitar.com/media/k2/attachments/GPCPA4_x.jpg"
                },
                new Guitar
                {
                    Company = MartinCo,
                    Model = "SS-GP42-15",
                    Description =
                        "2015 Winter NAMM Show Special – the SS-GP42-15 – is a spectacular stage performance guitar. With Martin’s new Vintage Tone System (VTS) Adirondack spruce soundboard and highly flamed Hawaiian koa back and sides, this Grand Performance acoustic-electric offers premium Style 42 appointments, state-of-the-art onboard Fishman Aura VT electronics, Madagascar rosewood bindings, and a polished gloss lacquer finish with “toasted sunburst” top shading. Personally signed by C. F. Martin IV and numbered in sequence, no more than fifty of these special guitars will be offered.",
                    BodyType = "Grand Performance 14 Fret Non-Cutaway",
                    TotalFrets = "20",
                    FinishTop = "Polished Gloss w/ Toasted Burst",
                    FinishNeck = "Polished Gloss",
                    FinishBackSides = "Polished Gloss",
                    Price = "10999.00",
                    Url = "https://www.martinguitar.com/new/item/3758-ss-gp42-15.html?Itemid=6",
                    ImgUrl = "https://www.martinguitar.com/media/k2/attachments/SS-GP42-15_x.jpg"
                },
                new Guitar
                {
                    Company = CarvinCo,
                    Model = "CT324C",
                    Description =
                        "The mahogany set-neck of the CT324 features our 'Rapid Play' low action neck, which assures effortless playability throughout the entire fingerboard, while the sleek set-in neck heel and lower body cutout allow easy uninhibited access at the 24th fret. The standard 25 inch scale, 14 inch radius fingerboard is ebony with abalone dot inlays, and other fingerboard woods, such as rosewood, maple, birdseye maple, flamed maple and zebrawood are available. You also can choose from an assortment of inlays made from genuine abalone or mother-of-pearl, in diamonds, blocks or our signature design. Standard frets are medium-jumbo nickel, with stainless steel, jumbo and low-wide frets optional.",
                    BodyType = "Honduras mahogany",
                    TotalFrets = "24",
                    FinishTop = "cutomizable",
                    FinishNeck = "cutomizable",
                    FinishBackSides = "cutomizable",
                    Price = "1199.00",
                    Url = "http://www.carvinguitars.com/guitars-in-stock/120560",
                    ImgUrl = "http://www.carvinguitars.com/guitargallery/images/full/ct324-tu-111769.jpg"
                },
                 new Guitar
                {
                    Company = CarvinCo,
                    Model = "JB200C Jason Becker Tribute Guitar'",
                    Description =
                        "In response to Jason Becker''s still-strong legions of fans around the world, Carvin Guitars has created the Jason Becker Tribute JB200C electric guitar. The Custom Shop worked with Jason to design this instrument as closely as possible to his original DC200. The JB200C is loaded with many upgraded standard features, combined with our state-of-the art modern manufacturing processes. With many available options, you can order your JB200C the way you want it, while maintaining the looks, playability and spirit of Jason''s original instrument. The JB200C is built in the USA, and is an instrument that you''ll be proud to play and own for years to come.",
                    BodyType = "alder with standard 4A flamed maple top",
                    TotalFrets = "24",
                    FinishTop = "flamed maple top",
                    FinishNeck = "tung-oiled",
                    FinishBackSides = "tung-oiled",
                    Price = "1699.00",
                    Url = "http://www.carvinguitars.com/catalog/guitars/jb200c",
                    ImgUrl = "http://www.carvinguitars.com/images/jb200c/2guitars-jb200c.jpg"
                }
            };
        }
    }
}

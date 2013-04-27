namespace PS2Outfit.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string Handle { get; set; }
        public virtual string FavoriteClass { get; set; }
        public virtual string FavoriteVehicle { get; set; }
        public virtual DateTime JoinDate { get; set; }
        public virtual string Server { get; set; }
        public virtual bool Active { get; set; }
        public virtual string Rank { get; set; }        
    }
}

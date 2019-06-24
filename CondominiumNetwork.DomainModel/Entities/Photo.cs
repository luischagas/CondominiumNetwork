using System.ComponentModel.DataAnnotations.Schema;
using System.IO;


namespace CondominiumNetwork.DomainModel.Entities
{
    public class Photo : EntityBase
    {
        public string ContainerName { get; set; }
        public string FileName { get; set; }
        [NotMapped]
        public Stream BinaryContent { get; set; } //Imagem (não armazena no BD)
        public string ContentType { get; set; }
    }
}

namespace Domain.Rooms.Entities
{
    public class Room
    {
        public int Id { get; set; } // Identificador único
        public string Name { get; set; } // Nome ou número da sala
        public int Capacity { get; set; } // Capacidade da sala (número de assentos)
        public bool IsActive { get; set; } // Indica se a sala está ativa
    }
}

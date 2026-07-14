using System.Globalization;

namespace HotelManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        List<Room> rooms = new List<Room>
        {
            new Room(101, "Single", 18), new Room(102, "Single", 20),
            new Room(201, "Double", 32), new Room(202, "Double", 35),
            new Room(301, "Suite", 60), new Room(302, "Suite", 75)
        };
        List<Guest> guests = new List<Guest>();
        bool running = true;

        while (running)
        {
            ShowMenu();
            switch (Console.ReadLine())
            {
                case "1": AddRoom(rooms); break;
                case "2": AddGuest(guests); break;
                case "3": BookRoom(rooms, guests); break;
                case "4": ViewRooms(rooms); break;
                case "5": ViewGuests(guests); break;
                case "6": SearchRooms(rooms); break;
                case "7": BookingStatistics(rooms, guests); break;
                case "8": UpdatePrice(rooms); break;
                case "9": GuestLookup(guests); break;
                case "10": RoomBreakdown(rooms); break;
                case "11": CheckOut(rooms, guests); break;
                case "12": RemoveUnavailableRooms(rooms, guests); break;
                case "13": ExtendStay(rooms, guests); break;
                case "14": HighestRevenue(rooms, guests); break;
                case "15": GuestPages(guests); break;
                case "0": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
            if (running) Pause();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n================================================");
        Console.WriteLine("GRAND VISTA HOTEL - MANAGEMENT SYSTEM");
        Console.WriteLine("================================================");
        Console.WriteLine("1. Add New Room"); Console.WriteLine("2. Register New Guest");
        Console.WriteLine("3. Book a Room for a Guest"); Console.WriteLine("4. View All Rooms");
        Console.WriteLine("5. View All Guests"); Console.WriteLine("6. Search & Filter Rooms");
        Console.WriteLine("7. Guest & Booking Statistics"); Console.WriteLine("8. Update Room Price");
        Console.WriteLine("9. Guest Lookup by Name"); Console.WriteLine("10. Room Type Breakdown Report");
        Console.WriteLine("11. Check Out a Guest"); Console.WriteLine("12. Remove Unavailable Rooms");
        Console.WriteLine("13. Extend Guest Stay"); Console.WriteLine("14. Highest Revenue Booking");
        Console.WriteLine("15. Guest Pagination Viewer"); Console.WriteLine("0. Exit");
        Console.Write("Enter your choice: ");
    }

    static void AddRoom(List<Room> rooms)
    {
        int number = ReadInt("Room number: ");
        if (number <= 0 || rooms.Any(r => r.roomNumber == number)) { Console.WriteLine("Room number is invalid or already exists."); return; }
        string type = ReadType();
        double price = ReadDouble("Price per night: ");
        if (price <= 0) { Console.WriteLine("Price must be positive."); return; }
        rooms.Add(new Room(number, type, price));
        Console.WriteLine($"Room {number} added. Total rooms: {rooms.Count()}");
    }

    static void AddGuest(List<Guest> guests)
    {
        string name = ReadText("Guest name: ");
        string date = ReadText("Check-in date: ");
        int nights = ReadInt("Number of nights: ");
        if (nights <= 0) { Console.WriteLine("Number of nights must be positive."); return; }
        string id = $"G{guests.Count() + 1:000}";
        guests.Add(new Guest(id, name, date, nights));
        Console.WriteLine($"Guest {id} registered for {name}.");
    }

    static void BookRoom(List<Room> rooms, List<Guest> guests)
    {
        string id = ReadText("Guest ID: ").ToUpper();
        int number = ReadInt("Room number: ");
        var guest = guests.FirstOrDefault(g => g.guestId == id);
        var room = rooms.FirstOrDefault(r => r.roomNumber == number);
        if (guest == null) { Console.WriteLine("Guest not found."); return; }
        if (room == null) { Console.WriteLine("Room not found."); return; }
        if (!room.isAvailable) { Console.WriteLine("Room is already booked."); return; }
        guest.roomNumber = room.roomNumber; room.isAvailable = false;
        Console.WriteLine($"Booking confirmed for {guest.guestName}. Room {room.roomNumber}, {room.roomType}, OMR {room.pricePerNight:F2} per night, {guest.totalNights} nights, total OMR {guest.calculateTotalCost(rooms):F2}.");
    }

    static void ViewRooms(List<Room> rooms)
    {
        if (!rooms.Any()) { Console.WriteLine("No rooms have been added yet."); return; }
        Console.WriteLine($"Rooms ({rooms.Count()}):");
        rooms.OrderBy(r => r.roomNumber).Select(r => r).ToList().ForEach(r => r.displayRoom());
    }

    static void ViewGuests(List<Guest> guests)
    {
        if (!guests.Any()) { Console.WriteLine("No guests have been registered yet."); return; }
        Console.WriteLine($"Guests ({guests.Count()}):");
        guests.OrderBy(g => g.guestName).Select(g => g).ToList().ForEach(g => g.displayGuest());
    }

    static void SearchRooms(List<Room> rooms)
    {
        while (true)
        {
            Console.WriteLine("\n1. Available rooms\n2. Filter by type\n3. Filter by max price\n4. Price statistics\n0. Back");
            string choice = Console.ReadLine() ?? "0";
            IEnumerable<Room> found = rooms;
            if (choice == "1") found = rooms.Where(r => r.isAvailable).OrderBy(r => r.pricePerNight);
            else if (choice == "2") { string type = ReadType(); found = rooms.Where(r => r.roomType.Equals(type, StringComparison.OrdinalIgnoreCase)); }
            else if (choice == "3") { double max = ReadDouble("Maximum price: "); found = rooms.Where(r => r.isAvailable && r.pricePerNight <= max).OrderBy(r => r.pricePerNight); }
            else if (choice == "4") { if (rooms.Any()) Console.WriteLine($"Total: {rooms.Count()}, Available: {rooms.Count(r => r.isAvailable)}, Average: OMR {rooms.Average(r => r.pricePerNight):F2}, Cheapest: OMR {rooms.Min(r => r.pricePerNight):F2}, Highest: OMR {rooms.Max(r => r.pricePerNight):F2}"); else Console.WriteLine("No rooms found for the selected criteria."); continue; }
            else if (choice == "0") return;
            else { Console.WriteLine("Invalid choice."); continue; }
            var list = found.Select(r => r).ToList();
            Console.WriteLine($"Results: {list.Count()}");
            if (!list.Any()) Console.WriteLine("No rooms found for the selected criteria."); else list.ForEach(r => r.displayRoom());
        }
    }

    static void BookingStatistics(List<Room> rooms, List<Guest> guests)
    {
        var active = guests.Where(g => g.roomNumber != 0);
        Console.WriteLine($"Registered guests: {guests.Count()}");
        Console.WriteLine($"Guests with rooms: {active.Count()}");
        Console.WriteLine($"Total rooms: {rooms.Count()}");
        Console.WriteLine($"Booked rooms: {rooms.Count(r => !r.isAvailable)}");
        if (!active.Any()) { Console.WriteLine("No active bookings recorded."); return; }
        Console.WriteLine($"Average nights: {active.Average(g => g.totalNights):F2}");
        Console.WriteLine("Top spending guests:");
        active.OrderByDescending(g => g.calculateTotalCost(rooms)).Take(3).Select(g => $"{g.guestName} - Room {g.roomNumber} - OMR {g.calculateTotalCost(rooms):F2}").ToList().ForEach(Console.WriteLine);
        active.Select(g => $"{g.guestName} - Room {g.roomNumber} - {g.totalNights} nights - OMR {g.calculateTotalCost(rooms):F2}").ToList().ForEach(Console.WriteLine);
    }

    static void UpdatePrice(List<Room> rooms)
    {
        var room = rooms.FirstOrDefault(r => r.roomNumber == ReadInt("Room number: "));
        if (room == null) { Console.WriteLine("Room not found."); return; }
        double old = room.pricePerNight, price = ReadDouble("New price: ");
        if (price <= 0) { Console.WriteLine("Price must be positive."); return; }
        room.pricePerNight = price; Console.WriteLine($"Price updated from OMR {old:F2} to OMR {price:F2}.");
    }

    static void GuestLookup(List<Guest> guests)
    {
        string search = ReadText("Name to search: ");
        var matches = guests.Where(g => g.guestName.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
        Console.WriteLine($"Matches: {matches.Count()}");
        if (!matches.Any()) Console.WriteLine("No guests matched that search.");
        else matches.Select(g => $"{g.guestId} | {g.guestName} | Room: {(g.roomNumber == 0 ? "Not Assigned" : g.roomNumber.ToString())}").ToList().ForEach(Console.WriteLine);
    }

    static void RoomBreakdown(List<Room> rooms)
    {
        foreach (string type in new[] { "Single", "Double", "Suite" })
        {
            int count = rooms.Count(r => r.roomType == type);
            Console.WriteLine($"{type}: {count} room(s), Average: {(count == 0 ? "N/A" : $"OMR {rooms.Where(r => r.roomType == type).Average(r => r.pricePerNight):F2}")}");
        }
        Console.WriteLine(rooms.Any() ? $"Overall average: OMR {rooms.Average(r => r.pricePerNight):F2}" : "Overall average: N/A");
    }

    static void CheckOut(List<Room> rooms, List<Guest> guests)
    {
        var guest = guests.FirstOrDefault(g => g.guestId == ReadText("Guest ID: ").ToUpper());
        if (guest == null) { Console.WriteLine("Guest not found."); return; }
        if (guest.roomNumber == 0) { Console.WriteLine("This guest has no active booking."); return; }
        var room = rooms.FirstOrDefault(r => r.roomNumber == guest.roomNumber);
        if (room == null) { Console.WriteLine("Room not found."); return; }
        Console.WriteLine($"Final bill: {guest.guestName}, Room {room.roomNumber}, {room.roomType}, Check-in {guest.checkInDate}, {guest.totalNights} nights, OMR {room.pricePerNight:F2} per night, Total OMR {guest.calculateTotalCost(rooms):F2}");
        if (ReadText("Confirm checkout (Y/N): ").Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            room.isAvailable = true; guests.Remove(guest);
            bool available = rooms.Any(r => r.roomNumber == room.roomNumber && r.isAvailable);
            Console.WriteLine($"Checkout completed. Rooms: {rooms.Count()}, Guests: {guests.Count()}, Room available: {available}");
        }
    }

    static void RemoveUnavailableRooms(List<Room> rooms, List<Guest> guests)
    {
        var removable = rooms.Where(r => !r.isAvailable && !guests.Any(g => g.roomNumber == r.roomNumber)).OrderBy(r => r.roomNumber).ToList();
        if (!removable.Any()) { Console.WriteLine("All unavailable rooms are currently occupied. No rooms can be decommissioned."); return; }
        removable.Select(r => $"Room {r.roomNumber} | {r.roomType} | OMR {r.pricePerNight:F2}").ToList().ForEach(Console.WriteLine);
        if (ReadText($"Remove {removable.Count()} room(s)? (Y/N): ").Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            rooms.RemoveAll(r => !r.isAvailable && !guests.Any(g => g.roomNumber == r.roomNumber));
            Console.WriteLine($"Rooms remaining: {rooms.Count()}");
            rooms.Select(r => $"{r.roomNumber} - {r.roomType}").ToList().ForEach(Console.WriteLine);
        }
    }

    static void ExtendStay(List<Room> rooms, List<Guest> guests)
    {
        var guest = guests.FirstOrDefault(g => g.guestId == ReadText("Guest ID: ").ToUpper());
        if (guest == null) { Console.WriteLine("Guest not found."); return; }
        if (guest.roomNumber == 0) { Console.WriteLine("This guest has no active booking to extend."); return; }
        int extra = ReadInt("Additional nights: ");
        if (extra <= 0) { Console.WriteLine("Additional nights must be positive."); return; }
        guest.totalNights += extra;
        Console.WriteLine($"Stay updated to {guest.totalNights} nights. New total: OMR {guest.calculateTotalCost(rooms):F2}");
    }

    static void HighestRevenue(List<Room> rooms, List<Guest> guests)
    {
        var highest = guests.Where(g => g.roomNumber != 0).Select(g => new { g.guestName, g.roomNumber, totalCost = g.calculateTotalCost(rooms) }).OrderByDescending(g => g.totalCost).Take(1).FirstOrDefault();
        if (highest == null) { Console.WriteLine("No active bookings recorded."); return; }
        Console.WriteLine($"Highest revenue booking: {highest.guestName}, Room {highest.roomNumber}, OMR {highest.totalCost:F2}");
    }

    static void GuestPages(List<Guest> guests)
    {
        int page = ReadInt("Page number: "); int size = 3;
        int totalPages = (int)Math.Ceiling(guests.Count() / (double)size);
        if (page < 1 || page > totalPages) { Console.WriteLine("That page does not exist."); return; }
        Console.WriteLine($"Page {page} of {totalPages}");
        guests.OrderBy(g => g.guestName).Skip((page - 1) * size).Take(size).Select(g => g).ToList().ForEach(g => g.displayGuest());
    }

    static string ReadText(string message) { Console.Write(message); return Console.ReadLine() ?? ""; }
    static int ReadInt(string message) { Console.Write(message); return int.TryParse(Console.ReadLine(), out int value) ? value : 0; }
    static double ReadDouble(string message) { Console.Write(message); return double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double value) ? value : 0; }
    static string ReadType()
    {
        string type = ReadText("Room type (Single/Double/Suite): ");
        return new[] { "Single", "Double", "Suite" }.FirstOrDefault(t => t.Equals(type, StringComparison.OrdinalIgnoreCase)) ?? "Single";
    }
    static void Pause() { Console.WriteLine("\nPress Enter to continue..."); Console.ReadLine(); }
}

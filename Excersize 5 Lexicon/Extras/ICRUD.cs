using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.Extras;

interface ICRUD : ICreate, IDelete, IRead<IVehicle>, IUpdate
{
}


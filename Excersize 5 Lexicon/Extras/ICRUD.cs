using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.Extras;

interface ICRUD<T> : ICreate, IDelete, IRead<T>, IUpdate where T : IVehicle
{
}


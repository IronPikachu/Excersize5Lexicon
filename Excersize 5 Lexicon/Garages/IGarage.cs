using Excersize_5_Lexicon.Vehicles;

namespace Excersize_5_Lexicon.Garages;

internal interface IGarage<T> : IGaragePropertys, IGarageMethodsIn<T>, IGarageMethodsOut<T>, IEnumerable<T> where T : Vehicle
{

}

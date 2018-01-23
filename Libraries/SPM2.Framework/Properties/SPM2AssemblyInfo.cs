using SPM2.Framework;

// This attribute tells the AddInProvider not to try to load any of the types in this assembly as AddIns. 
// Used for optimizing load speed of the AddInProvider.
[assembly: LoadAddInTypes(false)]
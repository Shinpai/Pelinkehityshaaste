using System.Collections.Generic;

public class Abi
{
    public List<object> inputs { get; set; }
    public bool payable { get; set; }
    public string stateMutability { get; set; }
    public string type { get; set; }
    public bool? constant { get; set; }
    public string name { get; set; }
    public List<object> outputs { get; set; }
}

public class ExportedSymbols
{
    public List<int> Marketplace { get; set; }
}

public class TypeDescriptions
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class TypeDescriptions2
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class BaseType
{
    public object contractScope { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string nodeType { get; set; }
    public int referencedDeclaration { get; set; }
    public string src { get; set; }
    public TypeDescriptions2 typeDescriptions { get; set; }
}

public class TypeDescriptions3
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class TypeDescriptions4
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class KeyType
{
    public int id { get; set; }
    public string name { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public TypeDescriptions4 typeDescriptions { get; set; }
}

public class TypeDescriptions5
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class ValueType
{
    public int id { get; set; }
    public string name { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public TypeDescriptions5 typeDescriptions { get; set; }
}

public class TypeName
{
    public BaseType baseType { get; set; }
    public int id { get; set; }
    public object length { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public TypeDescriptions3 typeDescriptions { get; set; }
    public KeyType keyType { get; set; }
    public ValueType valueType { get; set; }
}

public class Body
{
    public int id { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public List<object> statements { get; set; }
}

public class Parameters
{
    public int id { get; set; }
    public string nodeType { get; set; }
    public List<object> parameters { get; set; }
    public string src { get; set; }
}

public class ReturnParameters
{
    public int id { get; set; }
    public string nodeType { get; set; }
    public List<object> parameters { get; set; }
    public string src { get; set; }
}

public class Node2
{
    public bool constant { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string nodeType { get; set; }
    public int scope { get; set; }
    public string src { get; set; }
    public bool stateVariable { get; set; }
    public string storageLocation { get; set; }
    public TypeDescriptions typeDescriptions { get; set; }
    public TypeName typeName { get; set; }
    public object value { get; set; }
    public string visibility { get; set; }
    public Body body { get; set; }
    public object documentation { get; set; }
    public bool? implemented { get; set; }
    public bool? isConstructor { get; set; }
    public bool? isDeclaredConst { get; set; }
    public List<object> modifiers { get; set; }
    public Parameters parameters { get; set; }
    public bool? payable { get; set; }
    public ReturnParameters returnParameters { get; set; }
    public string stateMutability { get; set; }
    public object superFunction { get; set; }
}

public class Node
{
    public int id { get; set; }
    public List<string> literals { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public string absolutePath { get; set; }
    public string file { get; set; }
    public int? scope { get; set; }
    public int? sourceUnit { get; set; }
    public List<object> symbolAliases { get; set; }
    public string unitAlias { get; set; }
    public List<object> baseContracts { get; set; }
    public List<object> contractDependencies { get; set; }
    public string contractKind { get; set; }
    public object documentation { get; set; }
    public bool? fullyImplemented { get; set; }
    public List<int?> linearizedBaseContracts { get; set; }
    public string name { get; set; }
    public List<Node2> nodes { get; set; }
}

public class Ast
{
    public string absolutePath { get; set; }
    public ExportedSymbols exportedSymbols { get; set; }
    public int id { get; set; }
    public string nodeType { get; set; }
    public List<Node> nodes { get; set; }
    public string src { get; set; }
}

public class ExportedSymbols2
{
    public List<int> Marketplace { get; set; }
}

public class TypeDescriptions6
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class TypeDescriptions7
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class BaseType2
{
    public object contractScope { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string nodeType { get; set; }
    public int referencedDeclaration { get; set; }
    public string src { get; set; }
    public TypeDescriptions7 typeDescriptions { get; set; }
}

public class TypeDescriptions8
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class TypeDescriptions9
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class KeyType2
{
    public int id { get; set; }
    public string name { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public TypeDescriptions9 typeDescriptions { get; set; }
}

public class TypeDescriptions10
{
    public string typeIdentifier { get; set; }
    public string typeString { get; set; }
}

public class ValueType2
{
    public int id { get; set; }
    public string name { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public TypeDescriptions10 typeDescriptions { get; set; }
}

public class TypeName2
{
    public BaseType2 baseType { get; set; }
    public int id { get; set; }
    public object length { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public TypeDescriptions8 typeDescriptions { get; set; }
    public KeyType2 keyType { get; set; }
    public ValueType2 valueType { get; set; }
}

public class Body2
{
    public int id { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public List<object> statements { get; set; }
}

public class Parameters2
{
    public int id { get; set; }
    public string nodeType { get; set; }
    public List<object> parameters { get; set; }
    public string src { get; set; }
}

public class ReturnParameters2
{
    public int id { get; set; }
    public string nodeType { get; set; }
    public List<object> parameters { get; set; }
    public string src { get; set; }
}

public class Node4
{
    public bool constant { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string nodeType { get; set; }
    public int scope { get; set; }
    public string src { get; set; }
    public bool stateVariable { get; set; }
    public string storageLocation { get; set; }
    public TypeDescriptions6 typeDescriptions { get; set; }
    public TypeName2 typeName { get; set; }
    public object value { get; set; }
    public string visibility { get; set; }
    public Body2 body { get; set; }
    public object documentation { get; set; }
    public bool? implemented { get; set; }
    public bool? isConstructor { get; set; }
    public bool? isDeclaredConst { get; set; }
    public List<object> modifiers { get; set; }
    public Parameters2 parameters { get; set; }
    public bool? payable { get; set; }
    public ReturnParameters2 returnParameters { get; set; }
    public string stateMutability { get; set; }
    public object superFunction { get; set; }
}

public class Node3
{
    public int id { get; set; }
    public List<string> literals { get; set; }
    public string nodeType { get; set; }
    public string src { get; set; }
    public string absolutePath { get; set; }
    public string file { get; set; }
    public int? scope { get; set; }
    public int? sourceUnit { get; set; }
    public List<object> symbolAliases { get; set; }
    public string unitAlias { get; set; }
    public List<object> baseContracts { get; set; }
    public List<object> contractDependencies { get; set; }
    public string contractKind { get; set; }
    public object documentation { get; set; }
    public bool? fullyImplemented { get; set; }
    public List<int?> linearizedBaseContracts { get; set; }
    public string name { get; set; }
    public List<Node4> nodes { get; set; }
}

public class LegacyAST
{
    public string absolutePath { get; set; }
    public ExportedSymbols2 exportedSymbols { get; set; }
    public int id { get; set; }
    public string nodeType { get; set; }
    public List<Node3> nodes { get; set; }
    public string src { get; set; }
}

public class Compiler
{
    public string name { get; set; }
    public string version { get; set; }
}

public class Events
{
}

public class Links
{
}

public class __invalid_type__58
{
    public Events events { get; set; }
    public Links links { get; set; }
    public string address { get; set; }
    public string transactionHash { get; set; }
}

public class Networks
{
    public __invalid_type__58 __invalid_name__58 { get; set; }
}

public class RootObject
{
    public string contractName { get; set; }
    public List<Abi> abi { get; set; }
    public string bytecode { get; set; }
    public string deployedBytecode { get; set; }
    public string sourceMap { get; set; }
    public string deployedSourceMap { get; set; }
    public string source { get; set; }
    public string sourcePath { get; set; }
    public Ast ast { get; set; }
    public LegacyAST legacyAST { get; set; }
    public Compiler compiler { get; set; }
    public Networks networks { get; set; }
    public string schemaVersion { get; set; }
    public System.DateTime updatedAt { get; set; }
}
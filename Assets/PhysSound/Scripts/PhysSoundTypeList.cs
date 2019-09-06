namespace PhysSound{
//DO NOT EDIT THIS FILE DIRECTLY! Use the editor provided under Window/PhysSound.
public class PhysSoundTypeList {
public static string[] PhysSoundTypes = new string[14] {"Water","Bread","Concrete","Ceramic","Clay","Wood","Carpet","Book","Phone","Pillow","GlassBottle","CoffeeCup","Plastic","Metal"};

public static string GetKey(int index) { return (index >= PhysSoundTypes.Length) || (index < 0) ? "" : PhysSoundTypes[index]; }

public static bool HasKey(int index) { return index < PhysSoundTypes.Length && index >= 0; }

}
}

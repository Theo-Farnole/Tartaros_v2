
# Ultimate Automatic Cheats Menu 

## Setup
Add the **CheatsMenu** component in your scene.
Default shorcut to open the cheats menu is SHIFT + C.

## How to create a cheat button ?

Set the **[CheatMethod]** attribute to the static method. The button will call this method. 
The **method** must be a **static**.
    
	[CheatMethod]
	public static void MyMethod()
	{
		// [...]
	}

## How to draw or hide cheat button in function of others fields ?
You can set an expression to a CheatMethod. This expression is a **string**. 


	private bool _aBooleanField = true;

	// works
    [CheatMethod("_aBooleanField")]
    public static void MyMethod() { }
    
WARNING: You only can provide a field in the same class. 
  
    class BoolWrapper
    {
	    public bool boolean = true;
    }

	private BoolWrapper _boolWrapper = new BoolWrapper();
    
    // Expression doesn't works
    [CheatMethod("_boolWrapper.boolean")]
    public static void MyMethod() { }


## How to override button's name ?

	// expression is needed
    [CheatMethod(null, "Overrided label")]
    public static void MyMethod() { }


## Authors
**Theo Farnole**  - [My Portfolio](tfarnole.me/)


Written with [StackEdit](https://stackedit.io/).

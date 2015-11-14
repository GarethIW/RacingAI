public var cars : GameObject[];
// What car is active at start
public var carNumber:int = 2;

function Start ()
{
	for( var i: int=0; i < cars.Length; i++){
	cars[i].SetActive(false);
	}
	cars[carNumber].SetActive(true);
}

    function Update(){
		if (Input.GetKeyUp ("space"))
         {
            if(carNumber < cars.Length -1) {
                   carNumber++;
            } else {
                   carNumber=0;
            }
            changeCars(carNumber);
         }
		
///////
		if (Input.GetKeyDown ("1"))
		{
		carNumber=0;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("2"))
		{
		carNumber=1;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("3"))
		{
		carNumber=2;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("4"))
		{
		carNumber=3;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("5"))
		{
		carNumber=4;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("6"))
		{
		carNumber=5;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("7"))
		{
		carNumber=6;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("8"))
		{
		carNumber=7;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("9"))
		{
		carNumber=8;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("0"))
		{
		carNumber=9;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("-"))
		{
		carNumber=10;
		changeCars(carNumber);
		}
//////
		if (Input.GetKeyDown ("="))
		{
		carNumber=11;
		changeCars(carNumber);
		}
		if (Input.GetKeyDown ("["))
		{
		carNumber=12;
		changeCars(carNumber);
		}
		if (Input.GetKeyDown ("]"))
		{
		carNumber=13;
		changeCars(carNumber);
		}
		
    }
     
    function changeCars(carNumber:int){
         for( var i: int=0; i < cars.Length; i++){
            cars[i].SetActive(false);
         }
         cars[carNumber].SetActive(true);

    }

 

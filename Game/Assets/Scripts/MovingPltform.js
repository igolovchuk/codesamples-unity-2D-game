
/*var doX : boolean;

var doY : boolean;

var xSpeed : float;

var ySpeed : float;

var timeOut : float;

var dir : int;

function Start(){
dir = 1;
}

function Update(){
if(doX == true){

moveX();
}
if(doY == true){

moveY();
}


}

function moveX(){

if(dir == 1){
this.gameObject.transform.position.x += xSpeed*Time.deltaTime;
yield WaitForSeconds(timeOut);
dir = 2;

}
if(dir == 2){
this.gameObject.transform.position.x -= xSpeed*Time.deltaTime;
yield WaitForSeconds(timeOut);
dir = 1;

}


}
function moveY(){

if(dir == 1){
this.gameObject.transform.position.y += ySpeed*Time.deltaTime;
yield WaitForSeconds(timeOut);
dir = 2;

}

if(dir == 2){
this.gameObject.transform.position.y -= ySpeed*Time.deltaTime;
yield WaitForSeconds(timeOut);
dir = 1;
}

}
*/

#pragma strict


	var speed : int = 3;
	var what : boolean = false;
	var whatway : int = 0;
	var timer : int = 0;
	var Maxtimer : int = 50;

	function Update(){

		if (what == false) {
						if (whatway == 0) {
				
								rigidbody2D.velocity.x = -speed;
						}
						if (whatway == 1) {
			
								rigidbody2D.velocity.y = -speed;
						}
				}
		if (what == true) {
						if (whatway == 0) {
			
								rigidbody2D.velocity.x = speed;
						}
						if (whatway == 1) {
			
								rigidbody2D.velocity.y = speed;
						}
				}
		timer += 1;
		if (timer >= Maxtimer) {
			timer = 0;

			if(what == false){

				what = true;
				timer = 0;
				return;
			}
		
			if(what == true){

				what = false;
				timer = 0;
				return;


			}

		}

	}

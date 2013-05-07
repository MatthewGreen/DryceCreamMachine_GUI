String incomingString = "";   // for incoming serial data
int led = 13;
//Slot A
int van_A;
int choc_A;
int top_A;

//Slot B
int van_B;
int choc_B;
int top_B;

//Slot C
int van_C;
int choc_C;
int top_C;

//Slot D
int van_D;
int choc_D;
int top_D;

//Slot E
int van_E;
int choc_E;
int top_E;

void setup() {
  Serial.begin(9600);     // opens serial port, sets data rate to 9600 bps
  pinMode(led,OUTPUT);
}

void loop() {

  // send data only when you receive data:
  while (Serial.available() > 0){
  
    //Read The Serial Port And Parse The Values To The Holding Variables
    van_A = Serial.parseInt();
    choc_A = Serial.parseInt();
    top_A = Serial.parseInt();
    van_B = Serial.parseInt();
    choc_B = Serial.parseInt();
    top_B = Serial.parseInt();
    van_C = Serial.parseInt();
    choc_C = Serial.parseInt();
    top_C = Serial.parseInt();
    van_D = Serial.parseInt();
    choc_D = Serial.parseInt();
    top_D = Serial.parseInt();
    van_E = Serial.parseInt();
    choc_E = Serial.parseInt();
    top_E = Serial.parseInt();
    
    //Check For The End Of The Line And Echo The Results
    if (Serial.read() == '\n'){
      digitalWrite(led, HIGH);
      delay(500);
      digitalWrite(led, LOW);
      delay(500);
      digitalWrite(led, HIGH);
      delay(500);
      digitalWrite(led, LOW);
      Serial.println(van_A);
      Serial.println(choc_A);
      Serial.println(top_A);
    }
    Serial.flush();
  }
}



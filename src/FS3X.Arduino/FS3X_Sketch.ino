bool isButtonDown;
int currentButton;

void setup() {

  // Set baud rate
  Serial.begin(9600);
  
  // Set internal pull up resitors
  pinMode (A0, INPUT_PULLUP);
  pinMode (A2, INPUT_PULLUP);

  isButtonDown = false;
  currentButton = 16;
}

void loop() {
  int a0 = analogRead(A0);
  float a0Voltage = a0 * (5.00/1023.00);

  int a2 = analogRead(A2);
  float a2Voltage = a2 * (5.00/1023.00);

  if(a0Voltage>4.00 && a2Voltage > 4.00 && isButtonDown == true){
    isButtonDown=false;
    if(currentButton != 16){
      Serial.println(currentButton - 1);
    }
    currentButton = 16;
  }else if(a0Voltage < 1.00 && a2Voltage > 4.00 && isButtonDown == false){
    Serial.println("1");
    isButtonDown=true;
    currentButton = 1;
  }else if(a0Voltage > 4.00 && a2Voltage < 1.00 && isButtonDown == false){
    Serial.println("5");
    isButtonDown=true;
    currentButton = 5;
  }else if(a0Voltage < 1.00 && a2Voltage < 1.00 && isButtonDown == false){
   Serial.println("8");
    isButtonDown=true;
    currentButton = 8;
  }

  delay(5);
}

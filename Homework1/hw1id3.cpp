#include <iostream>
using namespace std;

//no data = -1
struct monks_t{
  int clas;
  int a1;
  int a2;
  int a3;
  int a4;
  int a5;
  int a6;
  int id;
  int numClasses = 8;
};

//no data = -1
struct poker_t{
  int clas;
  int s1;
  int c1;
  int s2;
  int c2;
  int s3;
  int c3;
  int s4;
  int c4;
  int s5;
  int c5;
  int numClasses = 11;
};

//no data = -1
struct votes_t{
  int clas; //dem=0 or repub=1 nah=-1
  int handicapp;
  int water;
  int adopt;
  int physician;
  int elSalvador;
  int religious;
  int antiSat;
  int aid;
  int mx;
  int immig;
  int synfuels;
  int education;
  int superfund;
  int crime;
  int duty;
  int exportAdmin;
  int numClasses = 17;
};

T[] parseData(int set){
  return (int[]){0,1,2};
}

int main(int argc, char* argv[])
{
  int dataSet = atoi(argv[1]);
  //parse the data into the structs using an array

  T fullData[];

  if (dataSet == 1 ){
    fullData = parseData(1);
    cout << fullData;
  }
  else if(dataSet == 2  ){
    fullData = parseData(2);
  }
  else if(dataSet == 3){
    fullData = parseData(3);
  }
  else{
    return -1;
  }



  //split into training and testing data

  //create disicsion tree using id3

  //print out tree????

  //test the tree using test array

  //output error

  cout << "Hello World!\n";
}

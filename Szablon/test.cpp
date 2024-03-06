#include <iostream>
#include <GL/glut.h>
using namespace std;


double dx = 0;
double dy = 0;
double x1 = 0, x2 = 0, yy1 = 0, y2 = 0, x = 0, y = 0, i = 0;
int step = 0;

void glInit()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glClearColor(0.0, 0.0, 0.0, 1.0);
	glMatrixMode(GL_PROJECTION);
	gluOrtho2D(0, 300, 0, 300);
}

void setPixel(int x, int y)
{
	glBegin(GL_POINTS);
	glVertex2i(x, y);
	glEnd();
}

void myDisplay()
{

	dx = (x2 - x1);
	dy = (y2 - yy1);

	if (abs(dx) >= abs(dy))
	{
		step = dx;
	}
	else
	{
		step = dy;
	}
	dx = dx / step;
	dy = dy / step;
	x = x1;
	y = yy1;
	i = 1;
	while (i <= step)
	{
		setPixel(x, y);
		x = x + dx;
		y = y + dy;
		i++;
	}
	glFlush();
	 
}

void startowa(int argcp, char** argv) {
	x1 = 100;
	x2 = 200;
	yy1 = 100;
	y2 = 200;
	glutInit(&argcp, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(300, 300);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("Test OpenGL");
	glInit();
	glutDisplayFunc(myDisplay);
	glutMainLoop();
}

void mniej_niz_czterdziecipiec(int argcp, char** argv) {
	x1 = 100;
	x2 = 200;
	yy1 = 150;
	y2 = 200;
	glutInit(&argcp, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(300, 300);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("Test OpenGL");
	glInit();
	glutDisplayFunc(myDisplay);
	glutMainLoop();
}
void wiecej_niz_czterdziecipiec(int argcp, char** argv) {
	x1 = 100;
	x2 = 200;
	yy1 = 50;
	y2 = 200;
	glutInit(&argcp, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(300, 300);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("Test OpenGL");
	glInit();
	glutDisplayFunc(myDisplay);
	glutMainLoop();
}

void pionowa(int argcp, char** argv) {
	x1 = 200;
	x2 = 200;
	yy1 = 100;
	y2 = 200;
	glutInit(&argcp, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(300, 300);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("Test OpenGL");
	glInit();
	glutDisplayFunc(myDisplay);
	glutMainLoop();
}

void pozioma(int argcp, char** argv) {
	x1 = 100;
	x2 = 200;
	yy1 = 200;
	y2 = 200;
	glutInit(&argcp, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(300, 300);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("Test OpenGL");
	glInit();
	glutDisplayFunc(myDisplay);
	glutMainLoop();
}

void ujemy_kierunkowy(int argcp, char** argv) {
	x1 = 100;
	x2 = 150;
	yy1 = 150;
	y2 = 100;
	glutInit(&argcp, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(300, 300);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("Test OpenGL");
	glInit();
	glutDisplayFunc(myDisplay);
	glutMainLoop();
}

int main(int argcp, char** argv)
{
	//startowa(argcp, argv);
	//mniej_niz_czterdziecipiec(argcp, argv);
	//wiecej_niz_czterdziecipiec(argcp, argv);
	//pionowa(argcp, argv);
	//pozioma(argcp, argv);
	//ujemy_kierunkowy(argcp, argv);

	return 0;


}
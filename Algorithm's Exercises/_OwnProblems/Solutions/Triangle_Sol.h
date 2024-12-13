struct Pt {
	int x;
	int y;
};

bool vectorialProduct(Pt V1, Pt V2, Pt V3);

void solveTriangle() {
	Pt pts[3], D;
	for (int i = 0; i < 3; i++)
		scanf("%d%d", &pts[i].x, &pts[i].y);
	cin >> D.x >> D.y;

	int triangleSign = vectorialProduct(pts[0], pts[1], pts[2]);
	int triangleSignA = vectorialProduct(pts[0], pts[1], D);
	int triangleSignB = vectorialProduct(pts[1], pts[2], D);
	int triangleSignC = vectorialProduct(pts[2], pts[0], D);

	cout << (3 * triangleSign == triangleSignA + triangleSignB + triangleSignC) << endl;
}

bool vectorialProduct(Pt V1, Pt V2, Pt V3)
{
	int result = (V1.x - V3.x) * (V2.y - V3.y) - (V1.y - V3.y) * (V2.x - V3.x);

	if (result == 0)
	{
		if ((V1.x - V2.x) * (V1.x - V2.x) + (V1.y - V2.y)*(V1.y - V2.y) >= (V1.x-V3.x)*(V1.x-V3.x)+(V1.y-V3.y)*(V1.y-V3.y))
			cout << 1;
		else
			cout << 0;

		cout << endl;
		exit(0);
	}

	return result > 0;
}
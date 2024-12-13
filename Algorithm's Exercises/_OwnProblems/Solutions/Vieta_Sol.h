
long long calcCoef(int m, int n, int roots[1000]);
long long nextComb(int kt, int p, int roots[1000], int &hasNext);
int updatePos(int k, int p, int pos[1000]);

void solveVieta() {
	int n;
	int roots[10];
	
	cin >> n;
	for (int i = 0; i < n; i++)
		scanf("%d", &roots[i]);

	long long coef[10];
	for (int i = 1; i <= n; i++)
		coef[i] = calcCoef(i, n, roots);
	
	if (n > 1)
		cout << "x^" << n;
	for (int i = 1; i < n-1; i++)
		if (coef[i] != 0 && coef[i] != 1)
			if (coef[i] == -1)
			printf("-x^%d", n-i);
		else
			printf("%+I64dx^%d", coef[i], n-i);
	if (coef[n-1] != 0 && coef[n-1] != 1)
		if (coef[n-1] == -1)
			printf("-x");
		else
		printf("%+I64dx", coef[n-1]);
	if (coef[n] != 0)
		printf("%+I64d", coef[n]);
	cout << endl;
}

long long calcCoef(int m, int n, int roots[10]) {
	long long coef = 0;
	int hasNext = 1;
	
	for (int i = 0; hasNext; i++) {
		coef += nextComb(m, n, roots, hasNext);
	}

	if (m % 2)
		coef=-coef;

	return coef;
}

long long nextComb(int kt, int p, int roots[10], int &hasNext) {
	static int k;
	static int pos[1000];

	long long comb = 1;
	if (k != kt) {
		k = kt;
		for (int i = 0; i < k; i++) {
			pos[i] = i;
			comb *= roots[i];
		}
		return comb;
	}

	hasNext = updatePos(k-1, p, pos);

	if (hasNext) {
		for (int i = 0; i < k; i++) {
			comb *= roots[pos[i]];
		}
		return comb;
	} else
		return 0;
}
int updatePos(int k, int p, int pos[10]) {
	pos[k]++;
	int hasNext = 1;

	if (pos[k] == p) {
		if (k == 0) {
			hasNext = 0;
		} else {
			hasNext = updatePos(k-1, p-1, pos);
			pos[k] = pos[k-1] + 1;
			if (pos[k] == p)
				hasNext = 0;
		}
	} 

	return hasNext;
}
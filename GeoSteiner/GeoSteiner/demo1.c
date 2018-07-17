/***********************************************************************

	$Id: demo1.c,v 1.9 2016/09/05 12:14:36 warme Exp $

	File:	demo1.c
	Rev:	e-2
	Date:	09/05/2016

	Copyright (c) 2003, 2016 by David M. Warme, Pawel Winter.
	This work is licensed under a Creative Commons Attribution
	4.0 International License.

************************************************************************

	GeoSteiner callable library demo program.

	Construct an Euclidean Steiner tree for the point set
	(0,0), (0,1), (1,0) and (1,1). Display length and Steiner
	points.

************************************************************************

	Modification Log:

	a-1:	02/02/2014	warme
		: Added include file.
	e-1:	04/14/2015	warme
		: Changes for 5.0 release.
	e-2:	09/05/2016	warme
		: Change notices for 5.1 release.

***********************************************************************/

#include "geosteiner.h"
#include "stdlib.h"

int main(int argc, char** argv)
{
	double terms[40] = { 0,0,1,9,1,14,3,4,4,10,4,13,5,3,5,15,7,0,7,8,9,3,10,5,10,11,10,14,12,1,13,3,14,10,14,12,15,5,15,7 };

	int i, nsps;
	double length, sps[100];
	int nedges;
	int edges[100];

	/* Open GeoSteiner environment */
	if (gst_open_geosteiner() != 0) {
		printf("Could not open GeoSteiner.\n");
		exit(1);
	}

	/* Compute Euclidean Steiner tree */
	gst_rsmt(20, terms, &length, &nsps, sps, &nedges, edges, NULL, NULL);

	/* Display information about solution */
	printf("Steiner tree has length %f\n", length);

	for (i = 0; i < nsps; i++) {
		printf("Steiner point: (%f, %f)\n", sps[2 * i], sps[2 * i + 1]);
	}

	for (i = 0; i < nedges; i++) {
		int p1 = edges[2 * i];
		int p2 = edges[2 * i + 1];
		double p1x, p1y, p2x, p2y;
		if (p1 < 20) {
			p1x = terms[2 * p1];
			p1y = terms[2 * p1 + 1];
		}
		else {
			p1x = sps[2 * p1 - 40];
			p1y = sps[2 * p1 + 1 - 40];
		}
		if (p2 < 20) {
			p2x = terms[2 * p2];
			p2y = terms[2 * p2 + 1];
		}
		else {
			p2x = sps[2 * p2 - 40];
			p2y = sps[2 * p2 + 1 - 40];
		}
		printf("Edge: (%f, %f), (%f, %f)\n", p1x, p1y, p2x, p2y);
	}

	/* Close GeoSteiner environment */
	gst_close_geosteiner();

	exit(0);
}

// external easy to use thing
__declspec(dllexport) int RectilinearSteiner(int nterms, double *terms) {
	if (gst_open_geosteiner() != 0) {
		printf("Could not open GeoSteiner.\n");
		return -1;
	}
	double length;
	gst_rsmt(nterms, terms, &length, NULL, NULL, NULL, NULL, NULL, NULL);
	gst_close_geosteiner();
	return length;
}
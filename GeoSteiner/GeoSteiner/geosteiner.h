#define GST_CHFLG_POSTSCRIPT                    0x01



//typedef size_t gst_channel_func(const char* buf, size_t cnt, void* handle);

typedef struct {
	short           indent;         /* columns, default = 0 */
	short           flags;          /* various options */
									/* The following items can only be "gotten", not "set" */
	int             column;         /* current column position */
	short           state;          /* various state flags */
									/* Reserved for future use */
	int             reserved1;
	int             reserved2;
} gst_channel_options;

typedef struct gst_destination *        gst_dest_ptr;


#if 0
/* For GST_PARAM_GROUP_DEFINITION */
#define GST_PVAL_GROUP_DEFINITION_ATLEAST               0
#define GST_PVAL_GROUP_DEFINITION_EXACTLY               1
#endif

/* For GST_PARAM_MULTIPLE_PRECISION */
#define GST_PVAL_MULTIPLE_PRECISION_OFF                 0
#define GST_PVAL_MULTIPLE_PRECISION_ONE_ITER            1
#define GST_PVAL_MULTIPLE_PRECISION_MORE_ITER           2

/* For GST_PARAM_EFST_HEURISTIC */
#define GST_PVAL_EFST_HEURISTIC_SLL                     0
#define GST_PVAL_EFST_HEURISTIC_ZW                      1

/* For GST_PARAM_BSD_METHOD */
#define GST_PVAL_BSD_METHOD_DYNAMIC                     0
#define GST_PVAL_BSD_METHOD_CONSTANT                    1
#define GST_PVAL_BSD_METHOD_LOGARITHMIC                 2

/* For GST_PARAM_LP_SOLVE_PERTURB */
#define GST_PVAL_LP_SOLVE_PERTURB_DISABLE               0
#define GST_PVAL_LP_SOLVE_PERTURB_ENABLE                1

/* For GST_PARAM_LP_SOLVE_SCALE */
#define GST_PVAL_LP_SOLVE_SCALE_DISABLE                 0
#define GST_PVAL_LP_SOLVE_SCALE_ENABLE                  1

/* For GST_PARAM_BRANCH_VAR_POLICY */
#define GST_PVAL_BRANCH_VAR_POLICY_NAIVE                0
#define GST_PVAL_BRANCH_VAR_POLICY_SMART                1
#define GST_PVAL_BRANCH_VAR_POLICY_PROD                 2
#define GST_PVAL_BRANCH_VAR_POLICY_WEAK                 3

/* For GST_PARAM_CHECK_ROOT_CONSTRAINTS */
#define GST_PVAL_CHECK_ROOT_CONSTRAINTS_DISABLE         0
#define GST_PVAL_CHECK_ROOT_CONSTRAINTS_ENABLE          1

/* For GST_PARAM_LOCAL_CUTS_MODE */
#define GST_PVAL_LOCAL_CUTS_MODE_DISABLE                0
#define GST_PVAL_LOCAL_CUTS_MODE_SUBTOUR_RELAXATION     1
#define GST_PVAL_LOCAL_CUTS_MODE_SUBTOUR_COMPONENTS     2
#define GST_PVAL_LOCAL_CUTS_MODE_BOTH                   3

/* For GST_PARAM_LOCAL_CUTS_MAX_DEPTH */
#define GST_PVAL_LOCAL_CUTS_MAX_DEPTH_DISABLE           0
#define GST_PVAL_LOCAL_CUTS_MAX_DEPTH_ONELEVEL          1
#define GST_PVAL_LOCAL_CUTS_MAX_DEPTH_TWOLEVELS         2
#define GST_PVAL_LOCAL_CUTS_MAX_DEPTH_ANYLEVEL          -1

/* For GST_PARAM_LOCAL_CUTS_TRACE_DEPTH */
#define GST_PVAL_LOCAL_CUTS_TRACE_DEPTH_DISABLE         0
#define GST_PVAL_LOCAL_CUTS_TRACE_DEPTH_ONELEVEL        1
#define GST_PVAL_LOCAL_CUTS_TRACE_DEPTH_TWOLEVELS       2
#define GST_PVAL_LOCAL_CUTS_TRACE_DEPTH_ANYLEVEL        -1

/* For GST_PARAM_SEED_POOL_WITH_2SECS */
#define GST_PVAL_SEED_POOL_WITH_2SECS_DISABLE           0
#define GST_PVAL_SEED_POOL_WITH_2SECS_ENSABLE           1

/* For GST_PARAM_INCLUDE_CORNERS */
#define GST_PVAL_INCLUDE_CORNERS_DISABLE                0
#define GST_PVAL_INCLUDE_CORNERS_ENABLE                 1

/* For GST_PARAM_SAVE_FORMAT */
#define GST_PVAL_SAVE_FORMAT_ORLIBRARY                  0
#define GST_PVAL_SAVE_FORMAT_STEINLIB                   1
#define GST_PVAL_SAVE_FORMAT_VERSION2                   2
#define GST_PVAL_SAVE_FORMAT_VERSION3                   3
#define GST_PVAL_SAVE_FORMAT_STEINLIB_INT               4

/* For GST_PARAM_GRID_OVERLAY */
#define GST_PVAL_GRID_OVERLAY_DISABLE                   0
#define GST_PVAL_GRID_OVERLAY_ENABLE                    1

/* For GST_PARAM_SOLVER_ALGORITHM */
#define GST_PVAL_SOLVER_ALGORITHM_AUTO                  0
#define GST_PVAL_SOLVER_ALGORITHM_BRANCH_AND_CUT        1
#define GST_PVAL_SOLVER_ALGORITHM_BACKTRACK_SEARCH      2


/* Solution status codes */

#define GST_STATUS_OPTIMAL     0  /* Optimal solution is available */
#define GST_STATUS_INFEASIBLE  1  /* Problem is infeasible */
#define GST_STATUS_FEASIBLE    2  /* Search incomplete, feasible known */
#define GST_STATUS_NO_FEASIBLE 3  /* Search incomplete, no feasible known */
#define GST_STATUS_NO_SOLUTION 4  /* Solver never invoked, or problem changed */

/* Black-box pointer types */

typedef struct gst_channel *    gst_channel_ptr;
typedef struct gst_hypergraph * gst_hg_ptr;
typedef struct gst_metric *     gst_metric_ptr;
typedef struct gst_param *      gst_param_ptr;
typedef struct gst_proplist *   gst_proplist_ptr;
typedef struct gst_scale_info * gst_scale_info_ptr;
typedef struct gst_solver *     gst_solver_ptr;

#define GST_CHFLG_POSTSCRIPT                    0x01
#define GST_ERR_BACKTRACK_OVERFLOW 1
#define GST_PROP_HG_NAME 1

#define GST_METRIC_NONE         0
#define GST_METRIC_L            1
#define GST_METRIC_UNIFORM      2

// im just going to define anything from bbmain as a random val
#define GST_PARAM_SEED_POOL_WITH_2SECS 1
#define GST_PARAM_BRANCH_VAR_POLICY 2
#define GST_PARAM_CPU_TIME_LIMIT 3
#define GST_PARAM_SOLVER_ALGORITHM 4
#define GST_PARAM_LOCAL_CUTS_MODE 5
#define GST_PARAM_LOCAL_CUTS_MAX_DEPTH 6
#define GST_PARAM_NUM_FEASIBLE_SOLUTIONS 7
#define GST_PARAM_LP_SOLVE_PERTURB 8
#define GST_PARAM_CHECK_ROOT_CONSTRAINTS 9
#define GST_PARAM_LP_SOLVE_SCALE 10
#define GST_PARAM_CHECK_BRANCH_VARS_THOROUGHLY 11
#define GST_PARAM_INITIAL_UPPER_BOUND 12
#define GST_PARAM_TARGET_POOL_NON_ZEROS 13
#define GST_ERR_UNKNOWN_PARAMETER_ID 14
#define GST_ERR_PARAMETER_VALUE_OUT_OF_RANGE 15
#define GST_PARAM_MERGE_CONSTRAINT_FILES 16
#define GST_PROP_SOLVER_ROOT_TIME 17
#define GST_PROP_SOLVER_ROOT_LENGTH 18
#define GST_PROP_SOLVER_CPU_TIME 19
#define GST_PROP_SOLVER_NUM_NODES 20
#define GST_PROP_SOLVER_NUM_LPS 21
#define GST_PROP_SOLVER_ROOT_OPTIMAL 22
#define GST_PROP_HG_MST_LENGTH 23
#define GST_PROP_SOLVER_ROOT_LPS 24
#define GST_PROP_SOLVER_INIT_PROWS 25
#define GST_PROP_SOLVER_INIT_PNZ 26
#define GST_PROP_SOLVER_INIT_LPROWS 27
#define GST_PROP_SOLVER_INIT_LPNZ 28
#define GST_PROP_SOLVER_ROOT_PROWS 29
#define GST_PROP_SOLVER_ROOT_PNZ 30
#define GST_PROP_SOLVER_ROOT_LPROWS 31
#define GST_PROP_SOLVER_ROOT_LPNZ 32
#define GST_PROP_SOLVER_FINAL_PROWS 33
#define GST_PROP_SOLVER_FINAL_PNZ 34
#define GST_PROP_SOLVER_FINAL_LPROWS 35
#define GST_PROP_SOLVER_FINAL_LPNZ 36
#define GST_SIG_FORCE_BRANCH 37
#define GST_SIG_STOP_TEST_BVAR 38
#define GST_SIG_STOP_SEP 39
#define GST_ERR_INVALID_CHANNEL 40


/* Parameter values */

#if 0
/* For GST_PARAM_GROUP_DEFINITION */
#define GST_PVAL_GROUP_DEFINITION_ATLEAST               0
#define GST_PVAL_GROUP_DEFINITION_EXACTLY               1
#endif

/* For GST_PARAM_MULTIPLE_PRECISION */
#define GST_PVAL_MULTIPLE_PRECISION_OFF                 0
#define GST_PVAL_MULTIPLE_PRECISION_ONE_ITER            1
#define GST_PVAL_MULTIPLE_PRECISION_MORE_ITER           2

/* For GST_PARAM_EFST_HEURISTIC */
#define GST_PVAL_EFST_HEURISTIC_SLL                     0
#define GST_PVAL_EFST_HEURISTIC_ZW                      1

/* For GST_PARAM_BSD_METHOD */
#define GST_PVAL_BSD_METHOD_DYNAMIC                     0
#define GST_PVAL_BSD_METHOD_CONSTANT                    1
#define GST_PVAL_BSD_METHOD_LOGARITHMIC                 2

/* For GST_PARAM_LP_SOLVE_PERTURB */
#define GST_PVAL_LP_SOLVE_PERTURB_DISABLE               0
#define GST_PVAL_LP_SOLVE_PERTURB_ENABLE                1

/* For GST_PARAM_LP_SOLVE_SCALE */
#define GST_PVAL_LP_SOLVE_SCALE_DISABLE                 0
#define GST_PVAL_LP_SOLVE_SCALE_ENABLE                  1

/* For GST_PARAM_BRANCH_VAR_POLICY */
#define GST_PVAL_BRANCH_VAR_POLICY_NAIVE                0
#define GST_PVAL_BRANCH_VAR_POLICY_SMART                1
#define GST_PVAL_BRANCH_VAR_POLICY_PROD                 2
#define GST_PVAL_BRANCH_VAR_POLICY_WEAK                 3

/* For GST_PARAM_CHECK_ROOT_CONSTRAINTS */
#define GST_PVAL_CHECK_ROOT_CONSTRAINTS_DISABLE         0
#define GST_PVAL_CHECK_ROOT_CONSTRAINTS_ENABLE          1

/* For GST_PARAM_LOCAL_CUTS_MODE */
#define GST_PVAL_LOCAL_CUTS_MODE_DISABLE                0
#define GST_PVAL_LOCAL_CUTS_MODE_SUBTOUR_RELAXATION     1
#define GST_PVAL_LOCAL_CUTS_MODE_SUBTOUR_COMPONENTS     2
#define GST_PVAL_LOCAL_CUTS_MODE_BOTH                   3

/* For GST_PARAM_LOCAL_CUTS_MAX_DEPTH */
#define GST_PVAL_LOCAL_CUTS_MAX_DEPTH_DISABLE           0
#define GST_PVAL_LOCAL_CUTS_MAX_DEPTH_ONELEVEL          1
#define GST_PVAL_LOCAL_CUTS_MAX_DEPTH_TWOLEVELS         2
#define GST_PVAL_LOCAL_CUTS_MAX_DEPTH_ANYLEVEL          -1

/* For GST_PARAM_LOCAL_CUTS_TRACE_DEPTH */
#define GST_PVAL_LOCAL_CUTS_TRACE_DEPTH_DISABLE         0
#define GST_PVAL_LOCAL_CUTS_TRACE_DEPTH_ONELEVEL        1
#define GST_PVAL_LOCAL_CUTS_TRACE_DEPTH_TWOLEVELS       2
#define GST_PVAL_LOCAL_CUTS_TRACE_DEPTH_ANYLEVEL        -1

/* For GST_PARAM_SEED_POOL_WITH_2SECS */
#define GST_PVAL_SEED_POOL_WITH_2SECS_DISABLE           0
#define GST_PVAL_SEED_POOL_WITH_2SECS_ENSABLE           1

/* For GST_PARAM_INCLUDE_CORNERS */
#define GST_PVAL_INCLUDE_CORNERS_DISABLE                0
#define GST_PVAL_INCLUDE_CORNERS_ENABLE                 1

/* For GST_PARAM_SAVE_FORMAT */
#define GST_PVAL_SAVE_FORMAT_ORLIBRARY                  0
#define GST_PVAL_SAVE_FORMAT_STEINLIB                   1
#define GST_PVAL_SAVE_FORMAT_VERSION2                   2
#define GST_PVAL_SAVE_FORMAT_VERSION3                   3
#define GST_PVAL_SAVE_FORMAT_STEINLIB_INT               4

/* For GST_PARAM_GRID_OVERLAY */
#define GST_PVAL_GRID_OVERLAY_DISABLE                   0
#define GST_PVAL_GRID_OVERLAY_ENABLE                    1

/* For GST_PARAM_SOLVER_ALGORITHM */
#define GST_PVAL_SOLVER_ALGORITHM_AUTO                  0
#define GST_PVAL_SOLVER_ALGORITHM_BRANCH_AND_CUT        1
#define GST_PVAL_SOLVER_ALGORITHM_BACKTRACK_SEARCH      2


/* Solution status codes */

#define GST_STATUS_OPTIMAL     0  /* Optimal solution is available */
#define GST_STATUS_INFEASIBLE  1  /* Problem is infeasible */
#define GST_STATUS_FEASIBLE    2  /* Search incomplete, feasible known */
#define GST_STATUS_NO_FEASIBLE 3  /* Search incomplete, no feasible known */
#define GST_STATUS_NO_SOLUTION 4  /* Solver never invoked, or problem changed */

/* Black-box pointer types */

typedef struct gst_channel *    gst_channel_ptr;
typedef struct gst_hypergraph * gst_hg_ptr;
typedef struct gst_metric *     gst_metric_ptr;
typedef struct gst_param *      gst_param_ptr;
typedef struct gst_proplist *   gst_proplist_ptr;
typedef struct gst_scale_info * gst_scale_info_ptr;
typedef struct gst_solver *     gst_solver_ptr;



#define GST_PARAM_CHECKPOINT_FILENAME 1 // no clue why these are ints or where they come from, whatever
#define GST_PARAM_PRINT_SOLVE_TRACE 1
#define GST_PROP_HG_GENERATION_TIME 1

// dunno


typedef struct gst_destination *        gst_dest_ptr;

#define GST_SOLVE_NORMAL		0
#define GST_SOLVE_GAP_TARGET		1
#define GST_SOLVE_LOWER_BOUND_TARGET	2
#define GST_SOLVE_UPPER_BOUND_TARGET	3
#define GST_SOLVE_MAX_BACKTRACKS	4
#define GST_SOLVE_MAX_FEASIBLE_UPDATES	5
#define GST_SOLVE_ABORT_SIGNAL		6
#define GST_SOLVE_TIME_LIMIT		7

#define GST_PROPTYPE_INTEGER    1
#define GST_PROPTYPE_DOUBLE     2
#define GST_PROPTYPE_STRING     3

#define stderr NULL // this might be a c/c++ difference, not sure how to do this properly, so making it null
#define stdout NULL
#define stdin NULL

#define GST_ERR_INVALID_NUMBER_OF_TERMINALS 41
#define GST_PROP_HG_INTEGRALITY_DELTA 42
#define GST_PROP_HG_HALF_FST_COUNT 43
#define GST_ERR_NO_STEINERS_ALLOWED 44
#define GST_ERR_INVALID_NUMBER_OF_EDGES 45
#define GST_ERR_INVALID_NUMBER_OF_VERTICES 46
#define GST_PARAM_MAX_FST_SIZE 46
#define GST_ERR_RANK_OUT_OF_RANGE 47
#define GST_SIG_ABORT 48
#define GST_PROP_SOLVER_LOWER_BOUND 49
#define GST_ERR_INVALID_CHANNEL_OPTIONS 50
#define GST_PARAM_GAP_TARGET 51
#define GST_PARAM_DETAILED_TIMINGS_CHANNEL 52
#define GST_PARAM_EFST_HEURISTIC 53
#define GST_PARAM_SAVE_FORMAT 54
#define GST_ERR_INVALID_METRIC 55
#define GST_PARAM_SAVE_INT_NUMBITS 56
#define GST_PARAM_GRID_OVERLAY 57
#define GST_ERR_INVALID_HYPERGRAPH 58
#define GST_ERR_INVALID_EDGE 59
#define GST_ERR_INVALID_DIMENSION 60
#define GST_ERR_NO_EMBEDDING 61
#define GST_ERR_INVALID_VERTEX 62
#define GST_ERR_LOAD_ERROR 63
#define GST_PROP_HG_PRUNING_TIME 64
#define GST_ERR_INVALID_PARAMETERS_OBJECT 65
#define GST_PARAMTYPE_INTEGER 66
#define GST_PARAMTYPE_DOUBLE 67
#define GST_PARAMTYPE_STRING 68
#define GST_PARAMTYPE_CHANNEL 69
#define GST_ERR_INVALID_PROPERTY_LIST 70
#define GST_ERR_PROPERTY_NOT_FOUND 71
#define GST_ERR_PROPERTY_TYPE_MISMATCH 72
#define GST_ERR_INVALID_PARAMETER_TYPE 73
#define GST_PARAM_BSD_METHOD 74
#define GST_PARAM_INCLUDE_CORNERS 75
#define GST_ERR_ALREADY_CLOSED 76
#define GST_ERR_LP_SOLVER_ACTIVE 77
#define GEOLIB_VERSION_STRING 78
#define GEOLIB_VERSION_MINOR 79
#define GEOLIB_VERSION_PATCH 80
#define GEOLIB_VERSION_PATCH 81
#define GEOLIB_VERSION_MAJOR 82
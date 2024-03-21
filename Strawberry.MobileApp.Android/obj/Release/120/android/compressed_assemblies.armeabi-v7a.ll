; ModuleID = 'obj\Release\120\android\compressed_assemblies.armeabi-v7a.ll'
source_filename = "obj\Release\120\android\compressed_assemblies.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.CompressedAssemblyDescriptor = type {
	i32,; uint32_t uncompressed_file_size
	i8,; bool loaded
	i8*; uint8_t* data
}

%struct.CompressedAssemblies = type {
	i32,; uint32_t count
	%struct.CompressedAssemblyDescriptor*; CompressedAssemblyDescriptor* descriptors
}
@__CompressedAssemblyDescriptor_data_0 = internal global [4342272 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_1 = internal global [335360 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_2 = internal global [194048 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_3 = internal global [259072 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_4 = internal global [119808 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_5 = internal global [488960 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_6 = internal global [17408 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_7 = internal global [30208 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_8 = internal global [33792 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_9 = internal global [91136 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_10 = internal global [10240 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_11 = internal global [63488 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_12 = internal global [24576 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_13 = internal global [186880 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_14 = internal global [27024 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_15 = internal global [214416 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_16 = internal global [192000 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_17 = internal global [31620520 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_18 = internal global [251800 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_19 = internal global [695336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_20 = internal global [176640 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_21 = internal global [128512 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_22 = internal global [19968 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_23 = internal global [50688 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_24 = internal global [172544 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_25 = internal global [101376 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_26 = internal global [5120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_27 = internal global [46592 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_28 = internal global [3091968 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_29 = internal global [35840 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_30 = internal global [50560 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_31 = internal global [156560 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_32 = internal global [414608 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_33 = internal global [633344 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_34 = internal global [2944000 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_35 = internal global [14752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_36 = internal global [15264 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_37 = internal global [268704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_38 = internal global [1095072 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_39 = internal global [39840 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_40 = internal global [1936272 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_41 = internal global [14752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_42 = internal global [171424 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_43 = internal global [15264 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_44 = internal global [28576 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_45 = internal global [125840 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_46 = internal global [14752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_47 = internal global [14240 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_48 = internal global [14752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_49 = internal global [292768 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_50 = internal global [15776 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_51 = internal global [22432 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_52 = internal global [129952 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_53 = internal global [15264 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_54 = internal global [14744 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_55 = internal global [15776 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_56 = internal global [14752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_57 = internal global [23600 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_58 = internal global [15264 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_59 = internal global [876944 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_60 = internal global [22432 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_61 = internal global [228752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_62 = internal global [15264 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_63 = internal global [15264 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_64 = internal global [15776 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_65 = internal global [15776 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_66 = internal global [42384 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_67 = internal global [224672 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_68 = internal global [147880 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_69 = internal global [2452896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_70 = internal global [1970064 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_71 = internal global [36864 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_72 = internal global [232328 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_73 = internal global [118688 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_74 = internal global [34736 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_75 = internal global [170912 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_76 = internal global [65928 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_77 = internal global [1029120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_78 = internal global [33184 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_79 = internal global [26536 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_80 = internal global [22408 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_81 = internal global [284536 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_82 = internal global [30088 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_83 = internal global [76712 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_84 = internal global [34216 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_85 = internal global [92160 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_86 = internal global [205728 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_87 = internal global [1726376 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_88 = internal global [56712 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_89 = internal global [65448 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_90 = internal global [28048 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_91 = internal global [59272 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_92 = internal global [311712 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_93 = internal global [21896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_94 = internal global [34184 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_95 = internal global [18832 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_96 = internal global [14216 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_97 = internal global [50080 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_98 = internal global [32160 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_99 = internal global [24456 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_100 = internal global [27552 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_101 = internal global [47008 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_102 = internal global [29608 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_103 = internal global [63904 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_104 = internal global [18808 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_105 = internal global [382344 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_106 = internal global [14216 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_107 = internal global [22416 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_108 = internal global [563592 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_109 = internal global [30624 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_110 = internal global [43400 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_111 = internal global [57344 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_112 = internal global [19360 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_113 = internal global [139776 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_114 = internal global [44424 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_115 = internal global [31112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_116 = internal global [108960 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_117 = internal global [85920 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_118 = internal global [53128 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_119 = internal global [623496 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_120 = internal global [210832 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_121 = internal global [20872 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_122 = internal global [137080 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_123 = internal global [107896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_124 = internal global [28024 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_125 = internal global [41352 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_126 = internal global [45944 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_127 = internal global [142704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_128 = internal global [60792 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_129 = internal global [337272 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_130 = internal global [1222032 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_131 = internal global [208784 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_132 = internal global [33680 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_133 = internal global [865792 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_134 = internal global [189328 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_135 = internal global [113552 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_136 = internal global [45968 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_137 = internal global [138120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_138 = internal global [363912 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_139 = internal global [1520640 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_140 = internal global [138104 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_141 = internal global [21880 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_142 = internal global [1365392 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_143 = internal global [873872 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_144 = internal global [86408 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_145 = internal global [572928 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_146 = internal global [52112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_147 = internal global [193936 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_148 = internal global [26752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_149 = internal global [142256 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_150 = internal global [15264 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_151 = internal global [2029992 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_152 = internal global [4514704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_153 = internal global [100768 x i8] zeroinitializer, align 1


; Compressed assembly data storage
@compressed_assembly_descriptors = internal global [154 x %struct.CompressedAssemblyDescriptor] [
	; 0
	%struct.CompressedAssemblyDescriptor {
		i32 4342272, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([4342272 x i8], [4342272 x i8]* @__CompressedAssemblyDescriptor_data_0, i32 0, i32 0); data
	}, 
	; 1
	%struct.CompressedAssemblyDescriptor {
		i32 335360, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([335360 x i8], [335360 x i8]* @__CompressedAssemblyDescriptor_data_1, i32 0, i32 0); data
	}, 
	; 2
	%struct.CompressedAssemblyDescriptor {
		i32 194048, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([194048 x i8], [194048 x i8]* @__CompressedAssemblyDescriptor_data_2, i32 0, i32 0); data
	}, 
	; 3
	%struct.CompressedAssemblyDescriptor {
		i32 259072, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([259072 x i8], [259072 x i8]* @__CompressedAssemblyDescriptor_data_3, i32 0, i32 0); data
	}, 
	; 4
	%struct.CompressedAssemblyDescriptor {
		i32 119808, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([119808 x i8], [119808 x i8]* @__CompressedAssemblyDescriptor_data_4, i32 0, i32 0); data
	}, 
	; 5
	%struct.CompressedAssemblyDescriptor {
		i32 488960, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([488960 x i8], [488960 x i8]* @__CompressedAssemblyDescriptor_data_5, i32 0, i32 0); data
	}, 
	; 6
	%struct.CompressedAssemblyDescriptor {
		i32 17408, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([17408 x i8], [17408 x i8]* @__CompressedAssemblyDescriptor_data_6, i32 0, i32 0); data
	}, 
	; 7
	%struct.CompressedAssemblyDescriptor {
		i32 30208, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30208 x i8], [30208 x i8]* @__CompressedAssemblyDescriptor_data_7, i32 0, i32 0); data
	}, 
	; 8
	%struct.CompressedAssemblyDescriptor {
		i32 33792, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([33792 x i8], [33792 x i8]* @__CompressedAssemblyDescriptor_data_8, i32 0, i32 0); data
	}, 
	; 9
	%struct.CompressedAssemblyDescriptor {
		i32 91136, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([91136 x i8], [91136 x i8]* @__CompressedAssemblyDescriptor_data_9, i32 0, i32 0); data
	}, 
	; 10
	%struct.CompressedAssemblyDescriptor {
		i32 10240, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([10240 x i8], [10240 x i8]* @__CompressedAssemblyDescriptor_data_10, i32 0, i32 0); data
	}, 
	; 11
	%struct.CompressedAssemblyDescriptor {
		i32 63488, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([63488 x i8], [63488 x i8]* @__CompressedAssemblyDescriptor_data_11, i32 0, i32 0); data
	}, 
	; 12
	%struct.CompressedAssemblyDescriptor {
		i32 24576, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([24576 x i8], [24576 x i8]* @__CompressedAssemblyDescriptor_data_12, i32 0, i32 0); data
	}, 
	; 13
	%struct.CompressedAssemblyDescriptor {
		i32 186880, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([186880 x i8], [186880 x i8]* @__CompressedAssemblyDescriptor_data_13, i32 0, i32 0); data
	}, 
	; 14
	%struct.CompressedAssemblyDescriptor {
		i32 27024, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([27024 x i8], [27024 x i8]* @__CompressedAssemblyDescriptor_data_14, i32 0, i32 0); data
	}, 
	; 15
	%struct.CompressedAssemblyDescriptor {
		i32 214416, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([214416 x i8], [214416 x i8]* @__CompressedAssemblyDescriptor_data_15, i32 0, i32 0); data
	}, 
	; 16
	%struct.CompressedAssemblyDescriptor {
		i32 192000, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([192000 x i8], [192000 x i8]* @__CompressedAssemblyDescriptor_data_16, i32 0, i32 0); data
	}, 
	; 17
	%struct.CompressedAssemblyDescriptor {
		i32 31620520, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([31620520 x i8], [31620520 x i8]* @__CompressedAssemblyDescriptor_data_17, i32 0, i32 0); data
	}, 
	; 18
	%struct.CompressedAssemblyDescriptor {
		i32 251800, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([251800 x i8], [251800 x i8]* @__CompressedAssemblyDescriptor_data_18, i32 0, i32 0); data
	}, 
	; 19
	%struct.CompressedAssemblyDescriptor {
		i32 695336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([695336 x i8], [695336 x i8]* @__CompressedAssemblyDescriptor_data_19, i32 0, i32 0); data
	}, 
	; 20
	%struct.CompressedAssemblyDescriptor {
		i32 176640, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([176640 x i8], [176640 x i8]* @__CompressedAssemblyDescriptor_data_20, i32 0, i32 0); data
	}, 
	; 21
	%struct.CompressedAssemblyDescriptor {
		i32 128512, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([128512 x i8], [128512 x i8]* @__CompressedAssemblyDescriptor_data_21, i32 0, i32 0); data
	}, 
	; 22
	%struct.CompressedAssemblyDescriptor {
		i32 19968, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([19968 x i8], [19968 x i8]* @__CompressedAssemblyDescriptor_data_22, i32 0, i32 0); data
	}, 
	; 23
	%struct.CompressedAssemblyDescriptor {
		i32 50688, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([50688 x i8], [50688 x i8]* @__CompressedAssemblyDescriptor_data_23, i32 0, i32 0); data
	}, 
	; 24
	%struct.CompressedAssemblyDescriptor {
		i32 172544, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([172544 x i8], [172544 x i8]* @__CompressedAssemblyDescriptor_data_24, i32 0, i32 0); data
	}, 
	; 25
	%struct.CompressedAssemblyDescriptor {
		i32 101376, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([101376 x i8], [101376 x i8]* @__CompressedAssemblyDescriptor_data_25, i32 0, i32 0); data
	}, 
	; 26
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([5120 x i8], [5120 x i8]* @__CompressedAssemblyDescriptor_data_26, i32 0, i32 0); data
	}, 
	; 27
	%struct.CompressedAssemblyDescriptor {
		i32 46592, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([46592 x i8], [46592 x i8]* @__CompressedAssemblyDescriptor_data_27, i32 0, i32 0); data
	}, 
	; 28
	%struct.CompressedAssemblyDescriptor {
		i32 3091968, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([3091968 x i8], [3091968 x i8]* @__CompressedAssemblyDescriptor_data_28, i32 0, i32 0); data
	}, 
	; 29
	%struct.CompressedAssemblyDescriptor {
		i32 35840, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([35840 x i8], [35840 x i8]* @__CompressedAssemblyDescriptor_data_29, i32 0, i32 0); data
	}, 
	; 30
	%struct.CompressedAssemblyDescriptor {
		i32 50560, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([50560 x i8], [50560 x i8]* @__CompressedAssemblyDescriptor_data_30, i32 0, i32 0); data
	}, 
	; 31
	%struct.CompressedAssemblyDescriptor {
		i32 156560, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([156560 x i8], [156560 x i8]* @__CompressedAssemblyDescriptor_data_31, i32 0, i32 0); data
	}, 
	; 32
	%struct.CompressedAssemblyDescriptor {
		i32 414608, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([414608 x i8], [414608 x i8]* @__CompressedAssemblyDescriptor_data_32, i32 0, i32 0); data
	}, 
	; 33
	%struct.CompressedAssemblyDescriptor {
		i32 633344, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([633344 x i8], [633344 x i8]* @__CompressedAssemblyDescriptor_data_33, i32 0, i32 0); data
	}, 
	; 34
	%struct.CompressedAssemblyDescriptor {
		i32 2944000, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2944000 x i8], [2944000 x i8]* @__CompressedAssemblyDescriptor_data_34, i32 0, i32 0); data
	}, 
	; 35
	%struct.CompressedAssemblyDescriptor {
		i32 14752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14752 x i8], [14752 x i8]* @__CompressedAssemblyDescriptor_data_35, i32 0, i32 0); data
	}, 
	; 36
	%struct.CompressedAssemblyDescriptor {
		i32 15264, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15264 x i8], [15264 x i8]* @__CompressedAssemblyDescriptor_data_36, i32 0, i32 0); data
	}, 
	; 37
	%struct.CompressedAssemblyDescriptor {
		i32 268704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([268704 x i8], [268704 x i8]* @__CompressedAssemblyDescriptor_data_37, i32 0, i32 0); data
	}, 
	; 38
	%struct.CompressedAssemblyDescriptor {
		i32 1095072, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1095072 x i8], [1095072 x i8]* @__CompressedAssemblyDescriptor_data_38, i32 0, i32 0); data
	}, 
	; 39
	%struct.CompressedAssemblyDescriptor {
		i32 39840, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([39840 x i8], [39840 x i8]* @__CompressedAssemblyDescriptor_data_39, i32 0, i32 0); data
	}, 
	; 40
	%struct.CompressedAssemblyDescriptor {
		i32 1936272, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1936272 x i8], [1936272 x i8]* @__CompressedAssemblyDescriptor_data_40, i32 0, i32 0); data
	}, 
	; 41
	%struct.CompressedAssemblyDescriptor {
		i32 14752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14752 x i8], [14752 x i8]* @__CompressedAssemblyDescriptor_data_41, i32 0, i32 0); data
	}, 
	; 42
	%struct.CompressedAssemblyDescriptor {
		i32 171424, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([171424 x i8], [171424 x i8]* @__CompressedAssemblyDescriptor_data_42, i32 0, i32 0); data
	}, 
	; 43
	%struct.CompressedAssemblyDescriptor {
		i32 15264, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15264 x i8], [15264 x i8]* @__CompressedAssemblyDescriptor_data_43, i32 0, i32 0); data
	}, 
	; 44
	%struct.CompressedAssemblyDescriptor {
		i32 28576, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([28576 x i8], [28576 x i8]* @__CompressedAssemblyDescriptor_data_44, i32 0, i32 0); data
	}, 
	; 45
	%struct.CompressedAssemblyDescriptor {
		i32 125840, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([125840 x i8], [125840 x i8]* @__CompressedAssemblyDescriptor_data_45, i32 0, i32 0); data
	}, 
	; 46
	%struct.CompressedAssemblyDescriptor {
		i32 14752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14752 x i8], [14752 x i8]* @__CompressedAssemblyDescriptor_data_46, i32 0, i32 0); data
	}, 
	; 47
	%struct.CompressedAssemblyDescriptor {
		i32 14240, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14240 x i8], [14240 x i8]* @__CompressedAssemblyDescriptor_data_47, i32 0, i32 0); data
	}, 
	; 48
	%struct.CompressedAssemblyDescriptor {
		i32 14752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14752 x i8], [14752 x i8]* @__CompressedAssemblyDescriptor_data_48, i32 0, i32 0); data
	}, 
	; 49
	%struct.CompressedAssemblyDescriptor {
		i32 292768, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([292768 x i8], [292768 x i8]* @__CompressedAssemblyDescriptor_data_49, i32 0, i32 0); data
	}, 
	; 50
	%struct.CompressedAssemblyDescriptor {
		i32 15776, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15776 x i8], [15776 x i8]* @__CompressedAssemblyDescriptor_data_50, i32 0, i32 0); data
	}, 
	; 51
	%struct.CompressedAssemblyDescriptor {
		i32 22432, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([22432 x i8], [22432 x i8]* @__CompressedAssemblyDescriptor_data_51, i32 0, i32 0); data
	}, 
	; 52
	%struct.CompressedAssemblyDescriptor {
		i32 129952, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([129952 x i8], [129952 x i8]* @__CompressedAssemblyDescriptor_data_52, i32 0, i32 0); data
	}, 
	; 53
	%struct.CompressedAssemblyDescriptor {
		i32 15264, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15264 x i8], [15264 x i8]* @__CompressedAssemblyDescriptor_data_53, i32 0, i32 0); data
	}, 
	; 54
	%struct.CompressedAssemblyDescriptor {
		i32 14744, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14744 x i8], [14744 x i8]* @__CompressedAssemblyDescriptor_data_54, i32 0, i32 0); data
	}, 
	; 55
	%struct.CompressedAssemblyDescriptor {
		i32 15776, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15776 x i8], [15776 x i8]* @__CompressedAssemblyDescriptor_data_55, i32 0, i32 0); data
	}, 
	; 56
	%struct.CompressedAssemblyDescriptor {
		i32 14752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14752 x i8], [14752 x i8]* @__CompressedAssemblyDescriptor_data_56, i32 0, i32 0); data
	}, 
	; 57
	%struct.CompressedAssemblyDescriptor {
		i32 23600, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([23600 x i8], [23600 x i8]* @__CompressedAssemblyDescriptor_data_57, i32 0, i32 0); data
	}, 
	; 58
	%struct.CompressedAssemblyDescriptor {
		i32 15264, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15264 x i8], [15264 x i8]* @__CompressedAssemblyDescriptor_data_58, i32 0, i32 0); data
	}, 
	; 59
	%struct.CompressedAssemblyDescriptor {
		i32 876944, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([876944 x i8], [876944 x i8]* @__CompressedAssemblyDescriptor_data_59, i32 0, i32 0); data
	}, 
	; 60
	%struct.CompressedAssemblyDescriptor {
		i32 22432, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([22432 x i8], [22432 x i8]* @__CompressedAssemblyDescriptor_data_60, i32 0, i32 0); data
	}, 
	; 61
	%struct.CompressedAssemblyDescriptor {
		i32 228752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([228752 x i8], [228752 x i8]* @__CompressedAssemblyDescriptor_data_61, i32 0, i32 0); data
	}, 
	; 62
	%struct.CompressedAssemblyDescriptor {
		i32 15264, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15264 x i8], [15264 x i8]* @__CompressedAssemblyDescriptor_data_62, i32 0, i32 0); data
	}, 
	; 63
	%struct.CompressedAssemblyDescriptor {
		i32 15264, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15264 x i8], [15264 x i8]* @__CompressedAssemblyDescriptor_data_63, i32 0, i32 0); data
	}, 
	; 64
	%struct.CompressedAssemblyDescriptor {
		i32 15776, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15776 x i8], [15776 x i8]* @__CompressedAssemblyDescriptor_data_64, i32 0, i32 0); data
	}, 
	; 65
	%struct.CompressedAssemblyDescriptor {
		i32 15776, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15776 x i8], [15776 x i8]* @__CompressedAssemblyDescriptor_data_65, i32 0, i32 0); data
	}, 
	; 66
	%struct.CompressedAssemblyDescriptor {
		i32 42384, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([42384 x i8], [42384 x i8]* @__CompressedAssemblyDescriptor_data_66, i32 0, i32 0); data
	}, 
	; 67
	%struct.CompressedAssemblyDescriptor {
		i32 224672, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([224672 x i8], [224672 x i8]* @__CompressedAssemblyDescriptor_data_67, i32 0, i32 0); data
	}, 
	; 68
	%struct.CompressedAssemblyDescriptor {
		i32 147880, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([147880 x i8], [147880 x i8]* @__CompressedAssemblyDescriptor_data_68, i32 0, i32 0); data
	}, 
	; 69
	%struct.CompressedAssemblyDescriptor {
		i32 2452896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2452896 x i8], [2452896 x i8]* @__CompressedAssemblyDescriptor_data_69, i32 0, i32 0); data
	}, 
	; 70
	%struct.CompressedAssemblyDescriptor {
		i32 1970064, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1970064 x i8], [1970064 x i8]* @__CompressedAssemblyDescriptor_data_70, i32 0, i32 0); data
	}, 
	; 71
	%struct.CompressedAssemblyDescriptor {
		i32 36864, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([36864 x i8], [36864 x i8]* @__CompressedAssemblyDescriptor_data_71, i32 0, i32 0); data
	}, 
	; 72
	%struct.CompressedAssemblyDescriptor {
		i32 232328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([232328 x i8], [232328 x i8]* @__CompressedAssemblyDescriptor_data_72, i32 0, i32 0); data
	}, 
	; 73
	%struct.CompressedAssemblyDescriptor {
		i32 118688, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([118688 x i8], [118688 x i8]* @__CompressedAssemblyDescriptor_data_73, i32 0, i32 0); data
	}, 
	; 74
	%struct.CompressedAssemblyDescriptor {
		i32 34736, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([34736 x i8], [34736 x i8]* @__CompressedAssemblyDescriptor_data_74, i32 0, i32 0); data
	}, 
	; 75
	%struct.CompressedAssemblyDescriptor {
		i32 170912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([170912 x i8], [170912 x i8]* @__CompressedAssemblyDescriptor_data_75, i32 0, i32 0); data
	}, 
	; 76
	%struct.CompressedAssemblyDescriptor {
		i32 65928, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([65928 x i8], [65928 x i8]* @__CompressedAssemblyDescriptor_data_76, i32 0, i32 0); data
	}, 
	; 77
	%struct.CompressedAssemblyDescriptor {
		i32 1029120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1029120 x i8], [1029120 x i8]* @__CompressedAssemblyDescriptor_data_77, i32 0, i32 0); data
	}, 
	; 78
	%struct.CompressedAssemblyDescriptor {
		i32 33184, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([33184 x i8], [33184 x i8]* @__CompressedAssemblyDescriptor_data_78, i32 0, i32 0); data
	}, 
	; 79
	%struct.CompressedAssemblyDescriptor {
		i32 26536, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26536 x i8], [26536 x i8]* @__CompressedAssemblyDescriptor_data_79, i32 0, i32 0); data
	}, 
	; 80
	%struct.CompressedAssemblyDescriptor {
		i32 22408, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([22408 x i8], [22408 x i8]* @__CompressedAssemblyDescriptor_data_80, i32 0, i32 0); data
	}, 
	; 81
	%struct.CompressedAssemblyDescriptor {
		i32 284536, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([284536 x i8], [284536 x i8]* @__CompressedAssemblyDescriptor_data_81, i32 0, i32 0); data
	}, 
	; 82
	%struct.CompressedAssemblyDescriptor {
		i32 30088, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30088 x i8], [30088 x i8]* @__CompressedAssemblyDescriptor_data_82, i32 0, i32 0); data
	}, 
	; 83
	%struct.CompressedAssemblyDescriptor {
		i32 76712, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([76712 x i8], [76712 x i8]* @__CompressedAssemblyDescriptor_data_83, i32 0, i32 0); data
	}, 
	; 84
	%struct.CompressedAssemblyDescriptor {
		i32 34216, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([34216 x i8], [34216 x i8]* @__CompressedAssemblyDescriptor_data_84, i32 0, i32 0); data
	}, 
	; 85
	%struct.CompressedAssemblyDescriptor {
		i32 92160, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([92160 x i8], [92160 x i8]* @__CompressedAssemblyDescriptor_data_85, i32 0, i32 0); data
	}, 
	; 86
	%struct.CompressedAssemblyDescriptor {
		i32 205728, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([205728 x i8], [205728 x i8]* @__CompressedAssemblyDescriptor_data_86, i32 0, i32 0); data
	}, 
	; 87
	%struct.CompressedAssemblyDescriptor {
		i32 1726376, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1726376 x i8], [1726376 x i8]* @__CompressedAssemblyDescriptor_data_87, i32 0, i32 0); data
	}, 
	; 88
	%struct.CompressedAssemblyDescriptor {
		i32 56712, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([56712 x i8], [56712 x i8]* @__CompressedAssemblyDescriptor_data_88, i32 0, i32 0); data
	}, 
	; 89
	%struct.CompressedAssemblyDescriptor {
		i32 65448, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([65448 x i8], [65448 x i8]* @__CompressedAssemblyDescriptor_data_89, i32 0, i32 0); data
	}, 
	; 90
	%struct.CompressedAssemblyDescriptor {
		i32 28048, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([28048 x i8], [28048 x i8]* @__CompressedAssemblyDescriptor_data_90, i32 0, i32 0); data
	}, 
	; 91
	%struct.CompressedAssemblyDescriptor {
		i32 59272, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([59272 x i8], [59272 x i8]* @__CompressedAssemblyDescriptor_data_91, i32 0, i32 0); data
	}, 
	; 92
	%struct.CompressedAssemblyDescriptor {
		i32 311712, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([311712 x i8], [311712 x i8]* @__CompressedAssemblyDescriptor_data_92, i32 0, i32 0); data
	}, 
	; 93
	%struct.CompressedAssemblyDescriptor {
		i32 21896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([21896 x i8], [21896 x i8]* @__CompressedAssemblyDescriptor_data_93, i32 0, i32 0); data
	}, 
	; 94
	%struct.CompressedAssemblyDescriptor {
		i32 34184, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([34184 x i8], [34184 x i8]* @__CompressedAssemblyDescriptor_data_94, i32 0, i32 0); data
	}, 
	; 95
	%struct.CompressedAssemblyDescriptor {
		i32 18832, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([18832 x i8], [18832 x i8]* @__CompressedAssemblyDescriptor_data_95, i32 0, i32 0); data
	}, 
	; 96
	%struct.CompressedAssemblyDescriptor {
		i32 14216, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14216 x i8], [14216 x i8]* @__CompressedAssemblyDescriptor_data_96, i32 0, i32 0); data
	}, 
	; 97
	%struct.CompressedAssemblyDescriptor {
		i32 50080, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([50080 x i8], [50080 x i8]* @__CompressedAssemblyDescriptor_data_97, i32 0, i32 0); data
	}, 
	; 98
	%struct.CompressedAssemblyDescriptor {
		i32 32160, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([32160 x i8], [32160 x i8]* @__CompressedAssemblyDescriptor_data_98, i32 0, i32 0); data
	}, 
	; 99
	%struct.CompressedAssemblyDescriptor {
		i32 24456, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([24456 x i8], [24456 x i8]* @__CompressedAssemblyDescriptor_data_99, i32 0, i32 0); data
	}, 
	; 100
	%struct.CompressedAssemblyDescriptor {
		i32 27552, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([27552 x i8], [27552 x i8]* @__CompressedAssemblyDescriptor_data_100, i32 0, i32 0); data
	}, 
	; 101
	%struct.CompressedAssemblyDescriptor {
		i32 47008, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([47008 x i8], [47008 x i8]* @__CompressedAssemblyDescriptor_data_101, i32 0, i32 0); data
	}, 
	; 102
	%struct.CompressedAssemblyDescriptor {
		i32 29608, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([29608 x i8], [29608 x i8]* @__CompressedAssemblyDescriptor_data_102, i32 0, i32 0); data
	}, 
	; 103
	%struct.CompressedAssemblyDescriptor {
		i32 63904, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([63904 x i8], [63904 x i8]* @__CompressedAssemblyDescriptor_data_103, i32 0, i32 0); data
	}, 
	; 104
	%struct.CompressedAssemblyDescriptor {
		i32 18808, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([18808 x i8], [18808 x i8]* @__CompressedAssemblyDescriptor_data_104, i32 0, i32 0); data
	}, 
	; 105
	%struct.CompressedAssemblyDescriptor {
		i32 382344, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([382344 x i8], [382344 x i8]* @__CompressedAssemblyDescriptor_data_105, i32 0, i32 0); data
	}, 
	; 106
	%struct.CompressedAssemblyDescriptor {
		i32 14216, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14216 x i8], [14216 x i8]* @__CompressedAssemblyDescriptor_data_106, i32 0, i32 0); data
	}, 
	; 107
	%struct.CompressedAssemblyDescriptor {
		i32 22416, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([22416 x i8], [22416 x i8]* @__CompressedAssemblyDescriptor_data_107, i32 0, i32 0); data
	}, 
	; 108
	%struct.CompressedAssemblyDescriptor {
		i32 563592, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([563592 x i8], [563592 x i8]* @__CompressedAssemblyDescriptor_data_108, i32 0, i32 0); data
	}, 
	; 109
	%struct.CompressedAssemblyDescriptor {
		i32 30624, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30624 x i8], [30624 x i8]* @__CompressedAssemblyDescriptor_data_109, i32 0, i32 0); data
	}, 
	; 110
	%struct.CompressedAssemblyDescriptor {
		i32 43400, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([43400 x i8], [43400 x i8]* @__CompressedAssemblyDescriptor_data_110, i32 0, i32 0); data
	}, 
	; 111
	%struct.CompressedAssemblyDescriptor {
		i32 57344, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([57344 x i8], [57344 x i8]* @__CompressedAssemblyDescriptor_data_111, i32 0, i32 0); data
	}, 
	; 112
	%struct.CompressedAssemblyDescriptor {
		i32 19360, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([19360 x i8], [19360 x i8]* @__CompressedAssemblyDescriptor_data_112, i32 0, i32 0); data
	}, 
	; 113
	%struct.CompressedAssemblyDescriptor {
		i32 139776, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([139776 x i8], [139776 x i8]* @__CompressedAssemblyDescriptor_data_113, i32 0, i32 0); data
	}, 
	; 114
	%struct.CompressedAssemblyDescriptor {
		i32 44424, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([44424 x i8], [44424 x i8]* @__CompressedAssemblyDescriptor_data_114, i32 0, i32 0); data
	}, 
	; 115
	%struct.CompressedAssemblyDescriptor {
		i32 31112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([31112 x i8], [31112 x i8]* @__CompressedAssemblyDescriptor_data_115, i32 0, i32 0); data
	}, 
	; 116
	%struct.CompressedAssemblyDescriptor {
		i32 108960, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([108960 x i8], [108960 x i8]* @__CompressedAssemblyDescriptor_data_116, i32 0, i32 0); data
	}, 
	; 117
	%struct.CompressedAssemblyDescriptor {
		i32 85920, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([85920 x i8], [85920 x i8]* @__CompressedAssemblyDescriptor_data_117, i32 0, i32 0); data
	}, 
	; 118
	%struct.CompressedAssemblyDescriptor {
		i32 53128, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([53128 x i8], [53128 x i8]* @__CompressedAssemblyDescriptor_data_118, i32 0, i32 0); data
	}, 
	; 119
	%struct.CompressedAssemblyDescriptor {
		i32 623496, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([623496 x i8], [623496 x i8]* @__CompressedAssemblyDescriptor_data_119, i32 0, i32 0); data
	}, 
	; 120
	%struct.CompressedAssemblyDescriptor {
		i32 210832, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([210832 x i8], [210832 x i8]* @__CompressedAssemblyDescriptor_data_120, i32 0, i32 0); data
	}, 
	; 121
	%struct.CompressedAssemblyDescriptor {
		i32 20872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([20872 x i8], [20872 x i8]* @__CompressedAssemblyDescriptor_data_121, i32 0, i32 0); data
	}, 
	; 122
	%struct.CompressedAssemblyDescriptor {
		i32 137080, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([137080 x i8], [137080 x i8]* @__CompressedAssemblyDescriptor_data_122, i32 0, i32 0); data
	}, 
	; 123
	%struct.CompressedAssemblyDescriptor {
		i32 107896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([107896 x i8], [107896 x i8]* @__CompressedAssemblyDescriptor_data_123, i32 0, i32 0); data
	}, 
	; 124
	%struct.CompressedAssemblyDescriptor {
		i32 28024, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([28024 x i8], [28024 x i8]* @__CompressedAssemblyDescriptor_data_124, i32 0, i32 0); data
	}, 
	; 125
	%struct.CompressedAssemblyDescriptor {
		i32 41352, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([41352 x i8], [41352 x i8]* @__CompressedAssemblyDescriptor_data_125, i32 0, i32 0); data
	}, 
	; 126
	%struct.CompressedAssemblyDescriptor {
		i32 45944, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([45944 x i8], [45944 x i8]* @__CompressedAssemblyDescriptor_data_126, i32 0, i32 0); data
	}, 
	; 127
	%struct.CompressedAssemblyDescriptor {
		i32 142704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([142704 x i8], [142704 x i8]* @__CompressedAssemblyDescriptor_data_127, i32 0, i32 0); data
	}, 
	; 128
	%struct.CompressedAssemblyDescriptor {
		i32 60792, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([60792 x i8], [60792 x i8]* @__CompressedAssemblyDescriptor_data_128, i32 0, i32 0); data
	}, 
	; 129
	%struct.CompressedAssemblyDescriptor {
		i32 337272, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([337272 x i8], [337272 x i8]* @__CompressedAssemblyDescriptor_data_129, i32 0, i32 0); data
	}, 
	; 130
	%struct.CompressedAssemblyDescriptor {
		i32 1222032, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1222032 x i8], [1222032 x i8]* @__CompressedAssemblyDescriptor_data_130, i32 0, i32 0); data
	}, 
	; 131
	%struct.CompressedAssemblyDescriptor {
		i32 208784, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([208784 x i8], [208784 x i8]* @__CompressedAssemblyDescriptor_data_131, i32 0, i32 0); data
	}, 
	; 132
	%struct.CompressedAssemblyDescriptor {
		i32 33680, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([33680 x i8], [33680 x i8]* @__CompressedAssemblyDescriptor_data_132, i32 0, i32 0); data
	}, 
	; 133
	%struct.CompressedAssemblyDescriptor {
		i32 865792, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([865792 x i8], [865792 x i8]* @__CompressedAssemblyDescriptor_data_133, i32 0, i32 0); data
	}, 
	; 134
	%struct.CompressedAssemblyDescriptor {
		i32 189328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([189328 x i8], [189328 x i8]* @__CompressedAssemblyDescriptor_data_134, i32 0, i32 0); data
	}, 
	; 135
	%struct.CompressedAssemblyDescriptor {
		i32 113552, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([113552 x i8], [113552 x i8]* @__CompressedAssemblyDescriptor_data_135, i32 0, i32 0); data
	}, 
	; 136
	%struct.CompressedAssemblyDescriptor {
		i32 45968, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([45968 x i8], [45968 x i8]* @__CompressedAssemblyDescriptor_data_136, i32 0, i32 0); data
	}, 
	; 137
	%struct.CompressedAssemblyDescriptor {
		i32 138120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([138120 x i8], [138120 x i8]* @__CompressedAssemblyDescriptor_data_137, i32 0, i32 0); data
	}, 
	; 138
	%struct.CompressedAssemblyDescriptor {
		i32 363912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([363912 x i8], [363912 x i8]* @__CompressedAssemblyDescriptor_data_138, i32 0, i32 0); data
	}, 
	; 139
	%struct.CompressedAssemblyDescriptor {
		i32 1520640, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1520640 x i8], [1520640 x i8]* @__CompressedAssemblyDescriptor_data_139, i32 0, i32 0); data
	}, 
	; 140
	%struct.CompressedAssemblyDescriptor {
		i32 138104, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([138104 x i8], [138104 x i8]* @__CompressedAssemblyDescriptor_data_140, i32 0, i32 0); data
	}, 
	; 141
	%struct.CompressedAssemblyDescriptor {
		i32 21880, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([21880 x i8], [21880 x i8]* @__CompressedAssemblyDescriptor_data_141, i32 0, i32 0); data
	}, 
	; 142
	%struct.CompressedAssemblyDescriptor {
		i32 1365392, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1365392 x i8], [1365392 x i8]* @__CompressedAssemblyDescriptor_data_142, i32 0, i32 0); data
	}, 
	; 143
	%struct.CompressedAssemblyDescriptor {
		i32 873872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([873872 x i8], [873872 x i8]* @__CompressedAssemblyDescriptor_data_143, i32 0, i32 0); data
	}, 
	; 144
	%struct.CompressedAssemblyDescriptor {
		i32 86408, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([86408 x i8], [86408 x i8]* @__CompressedAssemblyDescriptor_data_144, i32 0, i32 0); data
	}, 
	; 145
	%struct.CompressedAssemblyDescriptor {
		i32 572928, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([572928 x i8], [572928 x i8]* @__CompressedAssemblyDescriptor_data_145, i32 0, i32 0); data
	}, 
	; 146
	%struct.CompressedAssemblyDescriptor {
		i32 52112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([52112 x i8], [52112 x i8]* @__CompressedAssemblyDescriptor_data_146, i32 0, i32 0); data
	}, 
	; 147
	%struct.CompressedAssemblyDescriptor {
		i32 193936, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([193936 x i8], [193936 x i8]* @__CompressedAssemblyDescriptor_data_147, i32 0, i32 0); data
	}, 
	; 148
	%struct.CompressedAssemblyDescriptor {
		i32 26752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26752 x i8], [26752 x i8]* @__CompressedAssemblyDescriptor_data_148, i32 0, i32 0); data
	}, 
	; 149
	%struct.CompressedAssemblyDescriptor {
		i32 142256, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([142256 x i8], [142256 x i8]* @__CompressedAssemblyDescriptor_data_149, i32 0, i32 0); data
	}, 
	; 150
	%struct.CompressedAssemblyDescriptor {
		i32 15264, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15264 x i8], [15264 x i8]* @__CompressedAssemblyDescriptor_data_150, i32 0, i32 0); data
	}, 
	; 151
	%struct.CompressedAssemblyDescriptor {
		i32 2029992, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2029992 x i8], [2029992 x i8]* @__CompressedAssemblyDescriptor_data_151, i32 0, i32 0); data
	}, 
	; 152
	%struct.CompressedAssemblyDescriptor {
		i32 4514704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([4514704 x i8], [4514704 x i8]* @__CompressedAssemblyDescriptor_data_152, i32 0, i32 0); data
	}, 
	; 153
	%struct.CompressedAssemblyDescriptor {
		i32 100768, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([100768 x i8], [100768 x i8]* @__CompressedAssemblyDescriptor_data_153, i32 0, i32 0); data
	}
], align 4; end of 'compressed_assembly_descriptors' array


; compressed_assemblies
@compressed_assemblies = local_unnamed_addr global %struct.CompressedAssemblies {
	i32 154, ; count
	%struct.CompressedAssemblyDescriptor* getelementptr inbounds ([154 x %struct.CompressedAssemblyDescriptor], [154 x %struct.CompressedAssemblyDescriptor]* @compressed_assembly_descriptors, i32 0, i32 0); descriptors
}, align 4


!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-4 @ 13ba222766e8e41d419327749426023194660864"}

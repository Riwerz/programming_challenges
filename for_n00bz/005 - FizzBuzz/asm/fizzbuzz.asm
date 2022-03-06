.686
.model FLAT

INCLUDELIB /masm32/lib/msvcrt.lib
printf PROTO C, :VARARG

.data
fmt_fizzbuzz db "%s", 10, 0                   ; '10': printf of msvcrt.dll doesn't accept "\n"
fmt_digit db "%d", 10, 0                   
FIZZ db "FIZZ", 0
BUZZ db "BUZZ", 0
FIZZBUZZ db "FIZZBUZZ", 0

.code
_main PROC
	mov ebx, 100
	mov ecx, ebx

	_mainloop:
		
		;fizz test
		mov eax, ecx
		mov edx, 0
		mov ebx, 3
		div ebx
		mov ebx, ecx
		cmp edx, 0
		jz _fizz

		;buzz test
		mov eax, ecx
		mov edx, 0
		mov ebx, 5
		div ebx
		mov ebx, ecx
		cmp edx, 0
		jz _buzz
			
		jmp _digit

		_fizz:
			;fizzbuzz test
			mov eax, ecx
			mov edx, 0
			mov ebx, 5
			div ebx
			mov ebx, ecx
			cmp edx, 0
			jz _fizzbuzz

			invoke printf, OFFSET fmt_fizzbuzz, OFFSET FIZZ, eax
			jmp _restore_counter

		_buzz:
			invoke printf, OFFSET fmt_fizzbuzz, OFFSET BUZZ, eax
			jmp _restore_counter

		_fizzbuzz:
			invoke printf, OFFSET fmt_fizzbuzz, OFFSET FIZZBUZZ, eax
			jmp _restore_counter

		_digit:
			;mov ecx, ebx	
			invoke printf, OFFSET fmt_digit, ecx, eax
		
		_restore_counter:
			mov ecx, ebx
		dec ecx
	jnz _mainloop
	
_main ENDP

END _main
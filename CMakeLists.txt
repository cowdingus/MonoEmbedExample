cmake_minimum_required(VERSION 3.16.3)

# CMake Submodules
include(FindPkgConfig)

project(MonoEmbed)

# Source Globbing
file(GLOB_RECURSE SOURCES CONFIGURE_DEPENDS src/*.cpp)

# Modules
pkg_check_modules(MONO2 REQUIRED mono-2)

# Configurations
set(CMAKE_EXPORT_COMPILE_COMMANDS 1)

add_executable("${PROJECT_NAME}" ${SOURCES})

# Use C++17
set_target_properties(
	"${PROJECT_NAME}"
	PROPERTIES
	CXX_STANDARD 17
	)

target_compile_options(
	"${PROJECT_NAME}" PRIVATE
	${MONO2_CFLAGS_OTHER}
	-Wall -Wextra -pedantic -rdynamic
	)

target_include_directories(
	"${PROJECT_NAME}" PRIVATE
	${MONO2_INCLUDE_DIRS}
	include
	)

target_link_directories(
	"${PROJECT_NAME}" PRIVATE
	${MONO2_LIBRARY_DIRS}
	)

target_link_libraries(
	"${PROJECT_NAME}"
	PRIVATE
	${MONO2_LIBRARIES}
	fmt
	)
